using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxBehavior : MonoBehaviour
{
    public bool collected;
    public GameObject spawner;


    // Start is called before the first frame update
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
            Instantiate(spawner, transform.position, Quaternion.identity);
            Object.Destroy(this.gameObject);
        }
    }
}