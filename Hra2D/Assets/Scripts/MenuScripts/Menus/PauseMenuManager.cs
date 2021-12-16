using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public bool isPlayerDead = false;

    public GameObject pauseMenu;

    public GameObject player;

    private readonly string messageDeath = "You have died! Play again.";

    private readonly string messagePause = "The game is paused.";

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pauseMenu?.GetComponent<PauseMenuScript>()?.SetPlayerInfo(messagePause);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu?.GetComponentInChildren<PauseMenuScript>()?.HandleMenuInvocation();
        }


        if (player == null && !isPlayerDead)
        {
            isPlayerDead = true;
            pauseMenu.GetComponentInChildren<PauseMenuScript>().MakeResumeUnable();
            pauseMenu.GetComponentInChildren<PauseMenuScript>().SetPlayerInfo(messageDeath);
            pauseMenu?.GetComponentInChildren<PauseMenuScript>()?.HandleMenuInvocation();
        }

    }
}
