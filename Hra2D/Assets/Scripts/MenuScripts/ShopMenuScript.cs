using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopMenuScript : MonoBehaviour
{

    public Text currentMoney;

    public Text currentAmmo;

    public int price;

    public LevelSpawnPoints spawnPoints;

    private PlayerController player;

    private Money pm;

    private Ammo pa;

    public GameObject buyButton;

    public GameObject shellsImage;

    public GameObject nextLevelButton;

    public GameObject mainMenuButton;

    public TMP_Text message;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        pm = player.GetComponent<Money>();
        pa = player.GetComponent<Ammo>();


        currentAmmo.text = "Currently have: " + pa.value;
        currentMoney.text = "Rubles remaining: " + pm.value;
    }

    public void LastLevel(){
        buyButton.SetActive(false);
        shellsImage.SetActive(false);
        nextLevelButton.SetActive(false);
        message.text = "You have escaped from USSR\nCongratulations";

        mainMenuButton.transform.position = new Vector3(0, mainMenuButton.transform.position.y, mainMenuButton.transform.position.z);
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

    // This is inspired by:
    //      https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html,
    //      https://stackoverflow.com/questions/45798666/move-transfer-gameobject-to-another-scene, 
    //      https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
    public IEnumerator PrepareGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();     // needed for unloading scene after the wanted one is loaded

        GameObject player = GameObject.FindGameObjectWithTag("Player");     // our player

        PlayerData pd = new PlayerData(player.GetComponent<PlayerController>());
                
        var newLevel = SceneManager.LoadSceneAsync(pd.achievedLevel, LoadSceneMode.Additive);

        while (!newLevel.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(pd.achievedLevel));  // moving our player to another scene(new level)

        player.transform.position = spawnPoints.spawnpoints[GetLevelNumber(pd.achievedLevel)];

        SceneManager.UnloadSceneAsync(currentScene);

        player.GetComponent<PlayerController>().InitializePlayer(pd);   // after the next scene is loaded and previous is unloading then initialize player data

    }

    private int GetLevelNumber(string levelName)
    {
        return int.Parse(levelName.Split('_')[1]);
    }
}
