using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLogic : MonoBehaviour
{
    public int checkpointNum = 1;
    private void OnTriggerEnter(Collider other)
    {
        print("Collision");
        // When colliding with a player, increment their current checkpoint
        if (other.gameObject.tag == "Player")
        {
            print("Is Player");
            if(other.GetComponent<KartCheckpointCounter>().currentCheckpoint == checkpointNum - 1) 
            {
                other.GetComponent<KartCheckpointCounter>().currentCheckpoint = checkpointNum;
            }
        }
    }
}
