using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public Camera cam;
    public GameObject virtualCam;

    public void Setup()
    {
        int layer = 6 + GameObject.FindObjectOfType<PlayerInputManager>().playerCount;
        virtualCam.layer = layer;
        var bitMask = (1 << layer)
            | (1 << 0)
            | (1 << 1)
            | (1 << 2)
            | (1 << 3)
            | (1 << 4)
            | (1 << 5);
        cam.cullingMask = bitMask;
        cam.gameObject.layer = layer;
    }
}