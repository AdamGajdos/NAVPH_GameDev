using UnityEngine;
using System.IO;
using TMPro;
using System.Collections;

public class SavedGamesMenuManager : ChoiceMenu
{

    private string path;

    public GameObject listItem;
    public GameObject listedSavesBoard;
    public GameStarter gameStarter;

    public int numberOfLevels;

    public TMP_Text warning;

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

    // Load every saved game in players PC
    public void LoadSavedGames()
    {
        if (Directory.Exists(path))
        {
            string[] namesFound = Directory.GetFiles(path);

            int namesCount = namesFound.Length;

            for (int i = 0; i < namesCount; i++)
            {
                string fileFoundPath = namesFound[i];

                string fileFoundName = Path.GetFileName(fileFoundPath).Split('.')[0];

                PlayerData pd = SavingSystem.LoadPlayerProgress(fileFoundName);

                AddItemToList(pd.GetPlayerInfo());
            }
        }
    }

    // add saved game to list of available saved  games in players PC
    private void AddItemToList(string pd)
    {
        GameObject tmp = Instantiate(listItem);

        tmp.GetComponentInChildren<TMP_Text>().text = pd;

        tmp.transform.SetParent(listedSavesBoard.transform);

        tmp.SetActive(true);
    }

    // prepare selected saved game
    public void SelectGame(string chosenSave)
    {
        warning.gameObject.SetActive(false);

        string selectedSave = chosenSave.Split('-')[0];     // get player name

        int selectedLevel = int.Parse((chosenSave.Split('-')[2]).Split('_')[1]);    // get achieved level


        if (selectedLevel >= numberOfLevels){
            StartCoroutine(ShowCompletion());
        }
        else {
            if (gameStarter != null)
                StartCoroutine(gameStarter.PrepareGame(selectedSave));    // load appropriate saved game
            else
                Debug.LogError("Game starter not found!!");
        }
    }

    // Handle click on button
    public override void HandleSelected(string choice)
    {
        SelectGame(choice);
    }

    public IEnumerator ShowCompletion(){
        warning.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f); 

        warning.gameObject.SetActive(false);
    }
}
