using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public GameObject resumeButton;

    // Resume paused game
    public void Resume()
    {
        Time.timeScale = 1f;
        GetParentObject().SetActive(false);
    }

    // There won't be saving process of player progression
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

 
    public void HandleMenuInvocation()
    {
        if (gameObject.activeInHierarchy)
        {
            HideMenu();
        }
        else
        {
            ShowMenu();
        }
    }

    // Find first TMP_Text and set its value to msg.(In this case this is GameObject PlayerInfo in PauseMenu which is
    // holding information for player whether he/she has paused game or died in game)
    public void SetPlayerInfo(string msg)
    {
        TMP_Text playerInfo = gameObject.GetComponentInChildren<TMP_Text>();

        playerInfo.text = msg;

    }

    // Make Resume button unavailable in case if the player have died
    public void MakeResumeUnable()
    {
        resumeButton.SetActive(false);
    }

    private void HideMenu()
    {
        GetParentObject().SetActive(false);
        Time.timeScale = 1f;
    }

    private void ShowMenu()
    {
        GetParentObject().SetActive(true);
        Time.timeScale = 0f;
    }

    private GameObject GetParentObject()
    {
        return gameObject.transform.parent.gameObject;
    }
}
