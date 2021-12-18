using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Money : MonoBehaviour
{
    public int value;

    void Start(){
        
        value = 0;

        UpdateText();
    }
    public void AddMoney(int value)
    {
        this.value += value;

        UpdateText();
    }

    public void SpendMoney(int value)
    {
        this.value -= value;
        UpdateText();

    }
    public void UpdateValue(int value)
    {
        this.value = value;

        UpdateText();
    }

    public delegate void OnMoneyChange(int value);

    public event OnMoneyChange moneyChanged;

    private void UpdateText()
    {
        moneyChanged?.Invoke(value);
    }
}
