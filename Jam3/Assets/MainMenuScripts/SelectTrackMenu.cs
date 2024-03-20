using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTrackMenu : MonoBehaviour
{
    public void PlayTrack1()
    {
        SceneManager.LoadScene("Track1");
    }
}
