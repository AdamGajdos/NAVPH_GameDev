using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float actualHealth;


    public delegate void OnHealthChange(float newHealth, float maxHealth);

    public event OnHealthChange healthChanged;


    // void Awake(){
        
    //     actualHealth = maxHealth;

    //     healthChanged?.Invoke(actualHealth, maxHealth);

    //     // UpdateSlider();

    //     // Debug.Log(actualHealth);
    // }

    void Start(){
        actualHealth = maxHealth;

        Debug.Log(actualHealth);

        healthChanged?.Invoke(maxHealth, maxHealth);
    }

    public void HandleHit(float damage){
        Debug.Log(actualHealth);


        Debug.Log("Handlujem hit");
        TakeDamage(damage);
        if (actualHealth <= 0){
            actualHealth = 0;
            Destroy(gameObject);

            if (gameObject.tag == "Player"){
                Debug.Log("Restart game");
                Time.timeScale = 0;
            }
        }

        healthChanged?.Invoke(actualHealth, maxHealth);

        
        // UpdateSlider();
        
    }

    // if Player stepped on mine take all of his/her life
    public void HandleMine()
    {
        Debug.Log("Might have step on mine");
        HandleHit(actualHealth);
    }
    private void TakeDamage(float damage){
        actualHealth -= damage;
    }

    public void RenewHealth()
    {
        actualHealth = maxHealth;

        // UpdateSlider();
        healthChanged?.Invoke(actualHealth, maxHealth);

    }

    public void UpdateValue(float value)
    {
        actualHealth = value;

        healthChanged?.Invoke(actualHealth, maxHealth);
    }

    // private void UpdateSlider()
    // {
    //     if (healthSlider != null){
    //         healthSlider.value = actualHealth/maxHealth;
    //     }
    // }

}
