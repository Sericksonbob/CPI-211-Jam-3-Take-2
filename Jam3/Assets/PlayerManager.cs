using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public Camera cam;
    public GameObject virtualCam;
    public Transform characterGFX;

    public void Setup()
    {
        int pcount = 0;
        foreach (PlayerInput pi in PlayerInput.all)
        {
            pcount++;
        }
        Debug.Log(pcount);
        int layer = 5 + pcount;
        Debug.Log(layer);
        virtualCam.layer = layer;
        var bitMask = (1 << 0)
            | (1 << 1)
            | (1 << 2)
            | (1 << 3)
            | (1 << 4)
            | (1 << 5)
            | (1 << layer);
        cam.cullingMask = bitMask;
        cam.gameObject.layer = layer;
    }
    public void updateCharacter(int charIndex)
    {
        for (int i = 0; i < characterGFX.childCount; i++){
            if (i == charIndex)
            {
                characterGFX.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                characterGFX.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}