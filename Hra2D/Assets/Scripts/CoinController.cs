using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinValue;

    private void OnTriggerEnter2D(Collider2D coll){

        if (coll.gameObject.tag == "Player"){

            coll.gameObject.GetComponent<Money>().AddMoney(coinValue);

            Destroy(gameObject);
        }
        

    }
}
