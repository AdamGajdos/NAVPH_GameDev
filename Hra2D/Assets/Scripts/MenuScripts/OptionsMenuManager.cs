using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
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
