using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    public GameObject previousPanel;
    public GameObject actualPanel;

    public void GoBack()
    {

        Debug.Log("Going to " + previousPanel.name);

        previousPanel.SetActive(true);
        actualPanel.SetActive(false);
    }
}
