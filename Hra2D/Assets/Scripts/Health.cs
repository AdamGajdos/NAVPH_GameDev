using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    private float actualHealth;

    public Slider healthSlider;

    void Awake(){
        
        actualHealth = maxHealth;

        UpdateSlider();

        Debug.Log(actualHealth);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleHit(float damage){
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
        
        UpdateSlider();
        
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

        UpdateSlider();
    }

    private void UpdateSlider()
    {
        if (healthSlider != null){
            healthSlider.value = actualHealth/maxHealth;
        }
    }

}
