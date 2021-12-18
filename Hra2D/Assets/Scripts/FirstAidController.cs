using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll){

        if (coll.gameObject.tag == "Player"){

            coll.gameObject.GetComponent<Health>().RenewHealth();

            Destroy(gameObject);
        }
        

    }
}
