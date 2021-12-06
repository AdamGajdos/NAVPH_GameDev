using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionMenuManager : MonoBehaviour
{
    private string mainGameScene = "SampleScene";
    public GameObject previousMenu;
    public void PlayGame()
    {

        // TODO :
        // - make that in the main game scene there is selected type of player
        // - get name of player for saving progress -> create SaveManager?

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
