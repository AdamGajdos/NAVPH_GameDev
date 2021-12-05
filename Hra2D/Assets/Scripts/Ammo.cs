using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;

    public Text ammoText;
    void Awake(){
        
        UpdateText();
    }


    // Start is called before the first frame update
    void Start()
    {
        
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

    private void UpdateText()
    {
        if (ammoText != null){
            ammoText.text = "Shells " + value;
        }
    }
}
