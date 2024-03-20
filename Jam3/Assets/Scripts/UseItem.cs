using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private float appleSpeed;
    public GameObject collider;
    public GameObject buzzsaw;
    private float distanceBehind = 2f;
    private Vector3 buzzsawPos;
    bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        appleSpeed = 15;
    }
    public void ItemButton(InputAction.CallbackContext ctx)
    {
        pressed = ctx.action.triggered && ctx.action.ReadValue<float>() > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            switch(collider.gameObject.GetComponent<CollectBox>().itemHeld)
            {
                //Speed boost
                case "Apple":
                    collider.gameObject.GetComponent<CollectBox>().itemHeld = "Empty";
                    this.gameObject.GetComponent<KartController>().currentSpeed += appleSpeed;
                    break;

                //Place to trap opponent's
                case "Buzzsaw":
                    collider.gameObject.GetComponent<CollectBox>().itemHeld = "Empty";
                    buzzsawPos = transform.position - transform.rotation * Vector3.forward * distanceBehind;
                    Instantiate(buzzsaw, buzzsawPos, Quaternion.identity);
                    break;
            }
        }
    }
}
