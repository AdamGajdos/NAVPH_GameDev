using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string playerName { get; }
    public string characterName { get; }
    public int ammo { get; }
    public int coins { get; }
    public string achievedLevel { get; }

    public PlayerData(PlayerController pc)
    {
        playerName = pc.playerName;
        characterName = pc.characterName;
        ammo = pc.ammo.value;
        coins = pc.coins;
        achievedLevel = pc.achievedLevel;
    }

    public PlayerData(string player_name, string character_name, int ammunition, int money, string achieved_level)
    {
        playerName = player_name;
        characterName = character_name;
        ammo = ammunition;
        coins = money;
        achievedLevel = achieved_level;
    }

    public void GetPlayerInfoDebug()
    {
        Debug.Log("Player name: " + playerName);
        Debug.Log("Character name: " + characterName);
        Debug.Log("Ammo: " + ammo);
        Debug.Log("Coins: " + coins);
        Debug.Log("Achieved level: " + achievedLevel);
        Debug.Log("-----------------------------------------");
    }

    public string GetPlayerInfo()
    {
        return playerName + "-" + characterName + "-" + achievedLevel;
    }
}
