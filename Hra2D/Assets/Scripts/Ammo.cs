using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammo : MonoBehaviour
{
    public int value;

    void Start(){       
        UpdateText();
    }

    public void Use(){
        value--;
        UpdateText();
    }

    public void Buy(int value)
    {
        this.value += value;

        UpdateText();
    }

     public void UpdateValue(int value)
    {
        this.value = value;

        UpdateText();
    }

    public delegate void OnAmmoChange(int value);

    public event OnAmmoChange ammoChanged;

    private void UpdateText()
    {
        ammoChanged?.Invoke(value);
    }
}
