using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenuScript : MonoBehaviour
{

    public Text currentMoney;

    public Text currentAmmo;

    public int price;

    public LevelSpawnPoints spawnPoints;

    private PlayerController player;

    private Money pm;

    private Ammo pa;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        pm = player.GetComponent<Money>();
        pa = player.GetComponent<Ammo>();


        currentAmmo.text = "Currently have: " + pa.value;
        currentMoney.text = "Rubles remaining: " + pm.value;
    }
    
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }


    public void BuyAmmo()
    {        
        if (pm.value >= price){
            pm.SpendMoney(price);
            
            pa.Buy(1); 

            currentAmmo.text = "Currently have: " + pa.value;

            currentMoney.text = "Rubles remaining: " + pm.value;

        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        StartCoroutine(PrepareGame());
    }

    public IEnumerator PrepareGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerData pd = new PlayerData(player.GetComponent<PlayerController>());
                
        var newLevel = SceneManager.LoadSceneAsync(pd.achievedLevel, LoadSceneMode.Additive);

        while (!newLevel.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(pd.achievedLevel));

        player.transform.position = spawnPoints.spawnpoints[GetLevelNumber(pd.achievedLevel)];

        SceneManager.UnloadSceneAsync(currentScene);

        player.GetComponent<PlayerController>().InitializePlayer(pd);

    }

    private int GetLevelNumber(string levelName)
    {
        return int.Parse(levelName.Split('_')[1]);
    }
}
