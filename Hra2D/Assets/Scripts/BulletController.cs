using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float headDamage;
    public float bodyDamage;

    //[SerializeField]
    //private Rigidbody2D rb;
    //private float shotForce = 350f;
    // private float deletionTimeAfterHit = 0.5f;

    // Update is called once per frame
    //void Start()
    //{
    //    Vector2 forwardDirection = GameObject.Find("Player").GetComponent<PlayerController>().IsFacingRight() ? Vector2.right : Vector2.left;
    // prerobit aby sa strielalo vzhladom k natoceniu hraca
    //    rb.AddForce(forwardDirection * shotForce);
    //}

    // pridat efekt zasahu
    // private void OnTriggerEnter2D()
    // {
    //     Destroy(this);
    // }

    private void OnTriggerEnter2D(Collider2D coll){

        if (coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "Collectible"){
            Debug.Log("Nic nerob");
        }
        else{

            if (coll.gameObject.tag == "Head"){
                Debug.Log("Zober viac zdravia");
                coll.gameObject.GetComponentInParent<Health>().HandleHit(headDamage); 
            }
            else if (coll.gameObject.tag == "Body"){
                Debug.Log("Zober zdravie");
                coll.gameObject.GetComponentInParent<Health>().HandleHit(bodyDamage);
            }

            if (coll.gameObject.tag != "Soldier" && coll.gameObject.tag != "Player"){
                Destroy(gameObject);
            }
        }

        
    }
}
