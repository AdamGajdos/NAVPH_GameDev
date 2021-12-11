using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public PlayableCharacters playableCharacters;
    public LevelSpawnPoints spawnpoints;

    private GameObject GetChosenPlayer(string characterName)
    {
        int indexChosen = 0;        // by default return 1-st playable character

        foreach (var character in playableCharacters.characters)
        {
            if (character.name.Equals(characterName))
            {
                return Instantiate(character);
            }
        }

        return Instantiate(playableCharacters.characters[indexChosen]);
    }

    public IEnumerator PrepareGame(string player_name)
    {
        if (playableCharacters.characters.Length > 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            PlayerData pd = SavingSystem.LoadPlayerProgress(player_name);

            if (pd != null)
            {
                GameObject player = GetChosenPlayer(pd.characterName);

                player.GetComponent<PlayerController>().InitializePlayer(pd);

                var newLevel = SceneManager.LoadSceneAsync(pd.achievedLevel, LoadSceneMode.Additive);

                while (!newLevel.isDone)
                {
                    yield return null;
                }

                SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(pd.achievedLevel));

                player.transform.position = spawnpoints.spawnpoints[GetLevelNumber(pd.achievedLevel)];

                SceneManager.UnloadSceneAsync(currentScene);
            }

            else
            {
                Debug.LogError("Save not found!!");
            }

        }
        else
        {
            Debug.Log("No playable characters available");
        }

    }

    private int GetLevelNumber(string levelName)
    {
        return int.Parse(levelName.Split('_')[1]);
    }
}
