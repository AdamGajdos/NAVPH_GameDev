using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject menuPanel;

    // This method is inspired by video: https://www.youtube.com/watch?v=xTvsKDkh2-Q
    public void MuteToggle(bool muted){
        if (muted)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;

    }
    public void BackToMainMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
