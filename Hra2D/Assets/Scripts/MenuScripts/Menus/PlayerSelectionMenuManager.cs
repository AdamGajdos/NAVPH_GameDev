using UnityEngine;
using TMPro;

public class PlayerSelectionMenuManager : ChoiceMenu
{
    public TMP_InputField playerName;
    private string backupName;      // in case if player doesn't write his/her player name
    public GameStarter gameStarter;

    private void Awake()
    {
        playerName = GameObject.Find("NameInput").GetComponent<TMP_InputField>();
        backupName = "AnonymousName" + (int)Random.Range(0, 10000);
        gameStarter = gameObject.GetComponent<GameStarter>();
    }

    private string GetChosenPlayerName()
    {
        return (!string.IsNullOrEmpty(playerName.text)) ? playerName.text : backupName;
    }

    // Handle players selection of hero he wants to play with
    public void HandlePlayerInput(string characterName)
    {
        string chosenPlayerName = GetChosenPlayerName();

        int startingAmmo = 30;      // default value
        int startingMoney = 0;      // default value
        string achievedLevel = "Level_0";   // first level
        float startingEnergy = 0;       // default value
        float startingHealth = 200;     // default value
        
        foreach (GameObject obj in gameStarter.playableCharacters.characters){
            if (obj.name == characterName){
                startingHealth = obj.GetComponent<Health>().maxHealth;
                break;
            }
        }

        PlayerData pd = new PlayerData(
            chosenPlayerName,
            characterName,
            startingAmmo,
            startingMoney,
            startingEnergy,
            startingHealth,
            achievedLevel
        );

        pd.GetPlayerInfoDebug();        // display data that are about to be saved

        SavingSystem.SavePlayerProgress(pd);

    }

    public void StartNewGame(string characterName)
    {

        if (gameStarter != null)
        {
            HandlePlayerInput(characterName);
            StartCoroutine(gameStarter.PrepareGame(GetChosenPlayerName()));
        }
        else
        {
            Debug.LogError("Game starter not found!!");
        }
    }

    public override void HandleSelected(string choice)
    {
        StartNewGame(choice);
    }
}
