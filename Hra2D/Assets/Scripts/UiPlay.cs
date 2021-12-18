using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPlay : MonoBehaviour
{

    public Slider healthSlider;
    public Slider energySlider;

    public Text moneyText;

    public Text ammoText;

    private Health playerHealth;

    private Energy playerEnergy;

    private Money playerMoney;

    private Ammo playerAmmo;

    public GameObject player;

    void Start(){
        LoadEverything();
    }

    public void LoadEverything(){
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null){

            playerHealth = player.GetComponent<Health>();
            playerEnergy = player.GetComponent<Energy>();
            playerMoney = player.GetComponent<Money>();
            playerAmmo = player.GetComponent<Ammo>();

            playerHealth.healthChanged += OnHealthChanged;
            playerEnergy.energyChanged += OnEnergyChanged;
            playerMoney.moneyChanged += OnMoneyChanged;
            playerAmmo.ammoChanged += OnAmmoChanged;
        }
    }

    private void OnHealthChanged(float newHealth, float maxHealth) {
        if (healthSlider != null){
            healthSlider.value = newHealth/maxHealth;
        }
    }

    private void OnEnergyChanged(float newEnergy, float maxEnergy) {
         if (energySlider != null)
            energySlider.value = newEnergy/maxEnergy;
    }

    private void OnMoneyChanged(int value) {
        if (moneyText != null){
            moneyText.text = "Rubles " + value;
        }
    }

    private void OnAmmoChanged(int value) {
         if (ammoText != null){
            ammoText.text = "Shells " + value;
        }
    }


}
