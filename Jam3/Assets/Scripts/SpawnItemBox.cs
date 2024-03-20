using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemBox : MonoBehaviour
{
    public float timeLeft;
    public GameObject newBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            Instantiate(newBox, transform.position, Quaternion.identity);
            Object.Destroy(this.gameObject);
        }
    }
}
