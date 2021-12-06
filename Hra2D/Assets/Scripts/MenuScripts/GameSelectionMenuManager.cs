using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionMenuManager : MonoBehaviour
{
    public GameObject newGameMenu;
    public GameObject savedGameMenu;
    public GameObject previousMenu;

    public void StartNewGame()
    {
        if(newGameMenu != null)
        {
            newGameMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void LoadSavedGame()
    {
        if(savedGameMenu != null)
        {
            savedGameMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void Back()
    {
        if (previousMenu != null)
        {
            previousMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
