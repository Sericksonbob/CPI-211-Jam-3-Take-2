using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzsawCollision : MonoBehaviour
{
    private float stallTime;
    public GameObject kart;
    private float originalAcceleration;
    private bool stunned;

    // Start is called before the first frame update
    void Start()
    {
        stallTime = 2f;
        originalAcceleration = kart.gameObject.GetComponent<KartController>().acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        if(stunned)
        {
            stallTime -= Time.deltaTime;
        }
        if(stallTime <= 0)
        {
            stunned = false;
            stallTime = 2f;
            kart.gameObject.GetComponent<KartController>().acceleration = originalAcceleration;
        }
    }

    //If enter buzzsaw
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Buzzsaw")
        {
            kart.gameObject.GetComponent<KartController>().currentSpeed = 0;
            kart.gameObject.GetComponent<KartController>().acceleration = 0;
            stunned = true;
            Object.Destroy(other.gameObject);
        }
    }
}
