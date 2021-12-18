using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject gameSelectionMenu;

    // Display menu where player can pick between Start of new game and Load the previously saved game
    public void PlayGame()
    {
        if (gameSelectionMenu != null)
        {
            gameSelectionMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    // Display options Menu
    public void SeeOptions()
    {
        if (optionMenu != null)
        {
            optionMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    // Quit the game
    public void EndGame()
    {
        Application.Quit();
    }
}
