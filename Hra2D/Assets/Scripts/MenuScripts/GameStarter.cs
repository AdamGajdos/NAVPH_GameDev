using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public PlayableCharacters playableCharacters;   // array of playable characters. Needed for instantiating
    public LevelSpawnPoints spawnpoints;        // spawn points for each level

    // Instantiate chosen player.
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

    // This is inspired by:
    //      https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html,
    //      https://stackoverflow.com/questions/45798666/move-transfer-gameobject-to-another-scene, 
    //      https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
    //
    //      This will load save based on player's name, instantiate Hero character(actually Igor or Yelena), initialize saved player's data
    //      and move hero to new scene(at the start of achieved level)
    public IEnumerator PrepareGame(string player_name)
    {
        if (playableCharacters.characters.Length > 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            PlayerData pd = SavingSystem.LoadPlayerProgress(player_name);

            if (pd != null)
            {
                GameObject player = GetChosenPlayer(pd.characterName);

                var newLevel = SceneManager.LoadSceneAsync(pd.achievedLevel, LoadSceneMode.Additive);

                while (!newLevel.isDone)
                {
                    yield return null;
                }

                SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(pd.achievedLevel));

                player.transform.position = spawnpoints.spawnpoints[GetLevelNumber(pd.achievedLevel)];

                SceneManager.UnloadSceneAsync(currentScene);
                
                player.GetComponent<PlayerController>().InitializePlayer(pd);
                
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
