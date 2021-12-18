using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject shopMenu;
    
    // When finnished point is entered set new level as achieved level(level to be played), save player's progress and show shop menu
    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            PlayerController player = coll.gameObject.GetComponent<PlayerController>();

            int newLevel = int.Parse(player.achievedLevel.Split('_')[1]) + 1;   // set the next level

            player.achievedLevel = "Level_" + newLevel;

            PlayerData pd = new PlayerData(player);

            SavingSystem.SavePlayerProgress(pd);
            
            Time.timeScale = 0;
            shopMenu.SetActive(true);
            
        }
    }

}
