using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWireController : MonoBehaviour
{

    public float damageEnter = 5f;

    public float damageStay = 0.2f;

    private void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Player"){
            coll.gameObject.GetComponentInParent<Health>().HandleHit(damageEnter); 
        }  
    }

    private void OnCollisionStay2D(Collision2D coll){
        if (coll.gameObject.tag == "Player"){
            coll.gameObject.GetComponentInParent<Health>().HandleHit(damageStay); 
        }  
    }
}
