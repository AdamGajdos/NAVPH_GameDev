using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;

    void Start(){
        
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
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
