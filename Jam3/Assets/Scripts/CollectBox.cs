using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBox : MonoBehaviour
{
    public bool hasItem;
    public string itemHeld;
    private int randNum;
    // Start is called before the first frame update
    void Start()
    {
        hasItem = false;
        itemHeld = "Empty";
    }

    // Update is called once per frame
    void Update()
    {
        if(itemHeld == "Empty")
        {
            hasItem = false;
        }
    }

    //When entering trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item Box")
        {
            //If player has no item(empty) then it will give an apple.
            if (hasItem == false)
            {
                //Generate Random Item
                randNum = Random.Range(1,3);
                switch(randNum)
                {
                    case 1:
                        itemHeld = "Apple";
                        break;

                    case 2:
                        itemHeld = "Buzzsaw";
                        break;
                }
                hasItem = true;
            }
            other.gameObject.GetComponent<ItemBoxBehavior>().collected = true;
        }
    }
}