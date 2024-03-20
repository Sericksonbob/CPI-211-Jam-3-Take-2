using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LeaderboardBehavior : MonoBehaviour
{
    public GameObject[] places = new GameObject[8];
    public int[] kartCheckpoints = new int[8];
    [SerializeField] private GameObject kart1;
    [SerializeField] private GameObject kart2;
    [SerializeField] private GameObject kart3;
    [SerializeField] private GameObject kart4;
    [SerializeField] private GameObject kart5;
    [SerializeField] private GameObject kart6;
    [SerializeField] private GameObject kart7;
    [SerializeField] private GameObject kart8;
    // Start is called before the first frame update
    void Start()
    {
        places[0] = kart1; 
        places[1] = kart2; 
        places[2] = kart3; 
        places[3] = kart4; 
        places[4] = kart5; 
        places[5] = kart6; 
        places[6] = kart7; 
        places[7] = kart8;
    }

    // Update is called once per frame
    void Update()
    {
        kartCheckpoints[0] = places[0].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[1] = places[1].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[2] = places[2].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[3] = places[3].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[4] = places[4].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[5] = places[5].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[6] = places[6].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        kartCheckpoints[7] = places[7].GetComponentInChildren<KartCheckpointCounter>().currentCheckpoint;
        Array.Sort(kartCheckpoints, places);
    }
}
