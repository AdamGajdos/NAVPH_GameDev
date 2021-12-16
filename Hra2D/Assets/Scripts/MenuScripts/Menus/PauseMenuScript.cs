using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public GameObject resumeButton;

    public void Resume()
    {
        Time.timeScale = 1f;
        GetParentObject().SetActive(false);
    }

    // there wont be saving process
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

    public void SetPlayerInfo(string msg)
    {
        TMP_Text playerInfo = gameObject.GetComponentInChildren<TMP_Text>();

        playerInfo.text = msg;

    }

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
