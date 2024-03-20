using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miiGraphics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SadFace()
    {
        if (!transform.parent.GetComponent<PartyFace>().sad)
            StartCoroutine(transform.parent.GetComponent<PartyFace>().SadFace());
    }
}
