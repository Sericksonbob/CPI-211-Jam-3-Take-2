using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, trackSelect, characterSelect;
    public int currentPlayerSelect = 0;
    public TextMeshProUGUI playerTurn;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void loadTrack(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void loadTrack(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void backFromCharacterSelect()
    {
        characterSelect.SetActive(false);
        mainMenu.SetActive(true);
        currentPlayerSelect = 1;
    }
    public void backFromTrackSelect()
    {
        trackSelect.SetActive(false);
        characterSelect.SetActive(true);
    }
    public void characterMenu()
    {
        characterSelect.SetActive(true);
        mainMenu.SetActive(false);
        playerTurn.text = "Player " + (currentPlayerSelect + 1) + ": Select your Character.";
    }
    public void trackMenu()
    {
        trackSelect.SetActive(true);
        characterSelect.SetActive(false);
    }
    public void selectCharacter(int i)
    {
        switch (currentPlayerSelect)
        {
            case 0:
                GameManager.instance.p1Character = i;
                break;
            case 1:
                GameManager.instance.p2Character = i;
                break;
            case 2:
                GameManager.instance.p3Character = i;
                break;
            case 3:
                GameManager.instance.p4Character = i;
                break;
        }
        Debug.Log(currentPlayerSelect + " has selected " + i);
        currentPlayerSelect++;
        if (currentPlayerSelect > 3)
        {
            trackMenu();
        }
        playerTurn.text = "Player " + (currentPlayerSelect + 1) + ": Select your Character.";
    }
}
