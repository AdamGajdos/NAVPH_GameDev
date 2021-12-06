using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedGamesMenuManager : MonoBehaviour
{
    public GameObject previousMenu;
    private string mainGameScene = "SampleScene";
    public void StartSavedGame()
    {
        // TODO :
        // - load saved game

        SceneManager.LoadScene(mainGameScene);
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
