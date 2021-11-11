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

        healthSlider.value = actualHealth/maxHealth;
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
        
        healthSlider.value = actualHealth/maxHealth;
        
    }

    private void TakeDamage(float damage){
        actualHealth -= damage;
    }
}
