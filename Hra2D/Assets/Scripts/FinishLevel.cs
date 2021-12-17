using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{

    public GameObject shopMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            PlayerController player = coll.gameObject.GetComponent<PlayerController>();

            int newLevel = int.Parse(player.achievedLevel.Split('_')[1]) + 1;

            player.achievedLevel = "Level_" + newLevel;

            PlayerData pd = new PlayerData(player);

            SavingSystem.SavePlayerProgress(pd);
            
            Time.timeScale = 0;
            shopMenu.SetActive(true);
            
        }
    }

}
