using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPositionUI : MonoBehaviour
{
    public GameObject positionText;
    public GameObject leaderboard;
    public GameObject playerKart;
    // Update is called once per frame
    void Update()
    {
        int i;
        for (i = 0; i < 8; i++)
        {
            if (leaderboard.GetComponent<LeaderboardBehavior>().places[i] == playerKart)
            {
                break;
            }
        }

        switch (i)
        {
            case 0:
                positionText.GetComponent<TextMeshProUGUI>().text = "8 / 8";
                break;
            case 1:
                positionText.GetComponent<TextMeshProUGUI>().text = "7 / 8";
                break;
            case 2:
                positionText.GetComponent<TextMeshProUGUI>().text = "6 / 8";
                break;
            case 3:
                positionText.GetComponent<TextMeshProUGUI>().text = "5 / 8";
                break;
            case 4:
                positionText.GetComponent<TextMeshProUGUI>().text = "4 / 8";
                break;
            case 5:
                positionText.GetComponent<TextMeshProUGUI>().text = "3 / 8";
                break;
            case 6:
                positionText.GetComponent<TextMeshProUGUI>().text = "2 / 8";
                break;
            case 7:
                positionText.GetComponent<TextMeshProUGUI>().text = "1 / 8";
                break;
            default: 
                break;
        }
    }
}
