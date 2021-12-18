using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string playerName { get; }
    public string characterName { get; }
    public int ammo { get; }
    public int money { get; }

    public float energy { get; }

    public float health { get; }

    public string achievedLevel { get; }

    public PlayerData(PlayerController pc)
    {
        playerName = pc.playerName;
        characterName = pc.characterName;
        ammo = pc.GetComponent<Ammo>().value;
        money = pc.GetComponent<Money>().value;
        energy = pc.GetComponent<Energy>().actualEnergy;
        health = pc.GetComponent<Health>().actualHealth;
        achievedLevel = pc.achievedLevel;
    }

    public PlayerData(string player_name, string character_name, int ammunition, int money, float actEnergy, float actHealth, string achieved_level)
    {
        playerName = player_name;
        characterName = character_name;
        ammo = ammunition;
        this.money = money;
        energy = actEnergy;
        health = actHealth;
        achievedLevel = achieved_level;
    }

    public string GetPlayerInfo()
    {
        return playerName + "-" + characterName + "-" + achievedLevel;
    }
}
