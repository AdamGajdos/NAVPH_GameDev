using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float headDamage;
    public float bodyDamage;
    
    private void OnTriggerEnter2D(Collider2D coll){

        // Make possible for bullet to come through another bullet, collectible item or barbed wire
        if (coll.gameObject.tag != "Bullet" && coll.gameObject.tag != "Collectible" && coll.gameObject.tag != "Wire"){
            if (coll.gameObject.tag == "Head"){
                coll.gameObject.GetComponentInParent<Health>().HandleHit(headDamage); 
            }
            
            else if (coll.gameObject.tag == "Body"){
                coll.gameObject.GetComponentInParent<Health>().HandleHit(bodyDamage);
            }

            if (coll.gameObject.tag != "Soldier" && coll.gameObject.tag != "Player"){
                Destroy(gameObject);
            }
        } 
    }
}
