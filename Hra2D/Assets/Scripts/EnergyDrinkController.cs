using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll){

        if (coll.gameObject.tag == "Player"){

            coll.gameObject.GetComponent<Energy>().Renew();

            Destroy(gameObject);
        }        
    }
}
