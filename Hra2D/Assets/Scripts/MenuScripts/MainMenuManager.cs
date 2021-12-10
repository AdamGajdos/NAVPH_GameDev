using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //private string mainGameScene = "SampleScene";
    public GameObject optionMenu;
    public GameObject gameSelectionMenu;

    public void PlayGame()
    {
        //SceneManager.LoadScene(mainGameScene);
        Debug.Log("Gonna list saved games and new game possibility");
        if (gameSelectionMenu != null)
        {
            gameSelectionMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void SeeOptions()
    {
        Debug.Log("Gonna display game Options");
        if (optionMenu != null)
        {
            optionMenu.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        Debug.Log("Im quitting ... In built version it should work!");
        Application.Quit();
    }
}