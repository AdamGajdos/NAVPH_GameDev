using UnityEngine;
using System.IO;
using TMPro;

public class SavedGamesMenuManager : ChoiceMenu
{

    private string path;

    public GameObject listItem;
    public GameObject listedSavesBoard;
    public GameStarter gameStarter;

    private void Awake()
    {
        listedSavesBoard = GameObject.Find("Content");
        gameStarter = gameObject.GetComponent<GameStarter>();
        path = SavingSystem.GetSavePath();
    }

    private void Start()
    {
        LoadSavedGames();
    }

    public void LoadSavedGames()
    {
        if (Directory.Exists(path))
        {
            string[] namesFound = Directory.GetFiles(path);

            int namesCount = namesFound.Length;

            Debug.Log("Number of files found " + namesCount);

            for (int i = 0; i < namesCount; i++)
            {
                string fileFoundPath = namesFound[i];

                string fileFoundName = Path.GetFileName(fileFoundPath).Split('.')[0];

                PlayerData pd = SavingSystem.LoadPlayerProgress(fileFoundName);

                AddItemToList(pd.GetPlayerInfo());
            }
        }
    }

    private void AddItemToList(string pd)
    {
        GameObject tmp = Instantiate(listItem);

        tmp.GetComponentInChildren<TMP_Text>().text = pd;

        tmp.transform.SetParent(listedSavesBoard.transform);

        tmp.SetActive(true);
    }

    public void SelectGame(string chosenSave)
    {
        string selectedSave = chosenSave.Split('-')[0];     // get player name

        if (gameStarter != null)
        {
            StartCoroutine(gameStarter.PrepareGame(selectedSave));    // load appropriate saved game
        }
        else
        {
            Debug.LogError("Game starter not found!!");
        }

    }

    public override void HandleSelected(string choice)
    {
        SelectGame(choice);
    }
}
