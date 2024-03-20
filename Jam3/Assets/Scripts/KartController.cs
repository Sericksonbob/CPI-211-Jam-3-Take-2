using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;
using UnityEngine.InputSystem;
using System;

public class KartController : MonoBehaviour
{
    private PostProcessVolume postVolume;
    private PostProcessProfile postProfile;

    public Transform kartModel;
    public Transform kartNormal;
    public Rigidbody sphere;
    public Material regular;
    public Material boost;

    public float speed, currentSpeed;
    float rotate, currentRotate;
    int driftDirection;
    float driftPower = 0;
    int driftMode = 0;
    bool first, second, third;
    Color c;

    [Header("Bools")]
    public bool drifting = false;

    [Header("Parameters")]

    public float acceleration = 25f;
    public float steering = 80f;
    public float gravity = 10f;
    public LayerMask layerMask;

    bool accelerating;
    bool braking;
    float steerDir;
    bool driftUp;
    bool driftDown;

    void Start()
    {

    }

    public void Accelerate(InputAction.CallbackContext ctx)
    {
        accelerating = ctx.action.triggered;
        //   Debug.Log("M:" + move);
    }
    public void Brake(InputAction.CallbackContext ctx)
    {
        braking = ctx.action.triggered;
        //   Debug.Log("M:" + move);
    }
    public void Steering(InputAction.CallbackContext ctx)
    {
        steerDir = ctx.ReadValue<float>();
        //   Debug.Log("M:" + move);
    }
    public void Drift(InputAction.CallbackContext ctx)
    {
        driftDown = ctx.action.triggered && ctx.action.ReadValue<float>() > 0;
        driftUp = ctx.action.triggered && ctx.action.ReadValue<float>() == default;
        if (driftDown)
        {
            Debug.Log("Drifting Pressed");
        }
        if (driftUp)
        {
            Debug.Log("Drifting Released");
        }
    }

    void Update()
    {

        //Follow collider
        transform.position = sphere.transform.position - new Vector3(0, .2f, 0);

        //Accelerate
        if (accelerating)
            speed = acceleration;

        //Steer
        if (steerDir != 0)
        {
            Steer(Math.Sign(steerDir), Mathf.Abs(steerDir));
        }

        //Drift
        if (driftDown && !drifting && steerDir != 0)
        {
            drifting = true;
            driftDirection = steerDir > 0 ? 1 : -1;

            kartModel.parent.DOComplete();
            kartModel.parent.DOPunchPosition(transform.up * .2f, .3f, 5, 1);

            kartModel.GetComponent<MeshRenderer>().material = boost;
        }

        //In the midst of a drift
        if (drifting)
        {
            float control = (driftDirection == 1) ? ExtensionMethods.Remap(steerDir, -1, 1, 0, 2) : ExtensionMethods.Remap(steerDir, -1, 1, 2, 0);
            float powerControl = (driftDirection == 1) ? ExtensionMethods.Remap(steerDir, -1, 1, .2f, 1) : ExtensionMethods.Remap(steerDir, -1, 1, 1, .2f);
            Steer(driftDirection, control/2.5f);
            driftPower += powerControl;

            if (driftPower > 25)
                driftMode = 1;
            if (driftPower > 50)
                driftMode = 2;
            if (driftPower > 75)
                driftMode = 2;
        }

        //Releasing the drift and getting a boost
        if (driftUp && drifting)
        {
            Boost();
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f); speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f); rotate = 0f;

        //Forward acceleration
        if (!braking)
            sphere.AddForce(kartModel.transform.forward * currentSpeed, ForceMode.Acceleration);
        else
            sphere.AddForce(-kartModel.transform.forward * 0.5f * currentSpeed, ForceMode.Acceleration);
        //Gravity
        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        //Steering
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position, Vector3.down, out hitOn, 1.1f);
        Physics.Raycast(transform.position, Vector3.down, out hitNear, 2.0f);

        //Normal rotation
        kartModel.parent.up = Vector3.Lerp(kartModel.parent.up, hitNear.normal, Time.deltaTime * 8.0f);
        kartModel.parent.Rotate(0, transform.eulerAngles.y, 0);
    }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }

    private void Speed(float x)
    {
        currentSpeed = x;
    }

    public void Boost()
    {
        drifting = false;
        DOVirtual.Float(currentSpeed * 3, currentSpeed, .3f * driftMode, Speed);
        driftPower = 0;

        kartModel.parent.DOLocalRotate(Vector3.zero, .5f).SetEase(Ease.OutBack);
        kartModel.GetComponent<MeshRenderer>().material = regular;

    }
}