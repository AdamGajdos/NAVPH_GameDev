using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionMenuManager : MonoBehaviour
{
    public GameObject newGameMenu;
    public GameObject savedGameMenu;
    public GameObject actualMenu;

    public void StartNewGame()
    {
        if(newGameMenu != null)
        {
            newGameMenu.SetActive(true);
            actualMenu.SetActive(false);
        }
    }

    public void LoadSavedGame()
    {
        if(savedGameMenu != null)
        {
            savedGameMenu.SetActive(true);
            actualMenu.SetActive(false);
        }
    }
}
