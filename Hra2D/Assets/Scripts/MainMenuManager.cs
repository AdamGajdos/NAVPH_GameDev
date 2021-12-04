using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private string mainGameScene = "SampleScene";
    public GameObject optionMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(mainGameScene);
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
