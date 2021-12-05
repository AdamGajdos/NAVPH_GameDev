using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Money : MonoBehaviour
{

    public int value;

    public Text moneyText;
    void Awake(){
        
        value = 0;

        UpdateMoneyText();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int value)
    {
        this.value += value;

        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null){
            moneyText.text = "Rubles " + value;
        }
    }
}
