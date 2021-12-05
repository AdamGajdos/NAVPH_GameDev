using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Energy : MonoBehaviour
{

    public float maxEnergy;
    public float actualEnergy;

    public Slider energySlider;

    void Awake(){
        
        actualEnergy = 0;

        UpdateSlider();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void UpdateSlider()
    {
        if (energySlider != null)
            energySlider.value = actualEnergy/maxEnergy;
    }
}
