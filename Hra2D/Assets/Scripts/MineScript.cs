using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{

    public GameObject explosionEffect;
    public Vector2 blastPower;

    private void Awake()
    {
        blastPower = new Vector2(400f, 400f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            // destroy explosion effect after playing effect of explosion ; 2f is random number just enough to see whole animation of explosion
            Destroy(Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity), 2f);

            Rigidbody2D rb = collision.collider.attachedRigidbody;

            if (rb != null)
            {
                rb.AddForceAtPosition(blastPower, collision.gameObject.transform.TransformPoint(collision.collider.attachedRigidbody.centerOfMass));

                rb.gameObject.GetComponent<Health>().HandleMine();
            }

            // destroy mine object
            Destroy(gameObject);
        }
    }
}
