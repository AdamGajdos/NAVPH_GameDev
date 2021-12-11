using UnityEngine;
using TMPro;

public class PlayerSelectionMenuManager : ChoiceMenu
{
    public TMP_InputField playerName;
    private string backupName;
    public GameStarter gameStarter;

    private void Awake()
    {
        playerName = GameObject.Find("NameInput").GetComponent<TMP_InputField>();
        backupName = "DummyName" + (int)Random.Range(0, 10000);
        gameStarter = gameObject.GetComponent<GameStarter>();
    }

    private string GetChosenPlayerName()
    {
        return (!string.IsNullOrEmpty(playerName.text)) ? playerName.text : backupName;
    }

    public void HandlePlayerInput(string characterName)
    {
        string chosenPlayerName = GetChosenPlayerName();

        int startingAmmo = 30;
        int startingMoney = 0;
        string achievedLevel = "Level_0";       // first level

        PlayerData pd = new PlayerData(
            chosenPlayerName,
            characterName,
            startingAmmo,
            startingMoney,
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
