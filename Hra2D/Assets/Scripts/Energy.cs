using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Energy : MonoBehaviour
{

    public float maxEnergy;
    public float actualEnergy;

    void Start(){
        
        actualEnergy = 0;

        UpdateSlider();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateValue(float value)
    {
        actualEnergy = value;

        UpdateSlider();
    }

    public void Renew()
    {
        actualEnergy = maxEnergy;
        UpdateSlider();
    }

    public void Decrease(float value){
        Debug.Log("Uberam energiu");
        if (actualEnergy - value > 0)
            actualEnergy -= value;
        else
            actualEnergy = 0;

        UpdateSlider();
    }

    public bool HasEnergy(){
        return actualEnergy > 0;
    }

    public delegate void OnEnergyChange(float newEnergy, float maxEnergy);

    public event OnEnergyChange energyChanged;

    private void UpdateSlider()
    {
        energyChanged?.Invoke(actualEnergy, maxEnergy);
    
    }
}
