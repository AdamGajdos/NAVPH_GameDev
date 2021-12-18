using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject menuPanel;

    public void MuteToggle(bool muted){
        if (muted)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;

    }
    public void BackToMainMenu()
    {
        Debug.Log("Goin back to main menu!");

        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
