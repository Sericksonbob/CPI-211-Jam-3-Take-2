using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int p1Character, p2Character, p3Character, p4Character;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
        if (GameObject.FindObjectOfType<PlayerInputManager>())
        {
            PlayerInputManager pm = GameObject.FindObjectOfType<PlayerInputManager>().GetComponent<PlayerInputManager>();
            Debug.Log("HALLA  " + pm.playerCount);
            int i = 0;
            foreach (PlayerInput pi in PlayerInput.all)
            {
                i++;
                Debug.Log("Player " + i + " is " + pi.gameObject);
                pi.gameObject.name = "Player" + i;
                if (i == 1)
                {
                    pi.transform.GetComponentInParent<PlayerManager>().updateCharacter(p1Character);
                }
                else if (i == 2)
                {
                    pi.transform.GetComponentInParent<PlayerManager>().updateCharacter(p2Character);
                }
                else if (i == 3)
                {
                    pi.transform.GetComponentInParent<PlayerManager>().updateCharacter(p3Character);
                }
                else
                {
                    pi.transform.GetComponentInParent<PlayerManager>().updateCharacter(p4Character);
                }
            }

        }
    }
}
