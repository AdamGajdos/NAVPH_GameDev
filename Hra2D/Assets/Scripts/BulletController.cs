using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float shotForce = 350f;
    private float deletionTimeAfterHit = 0.5f;

    // Update is called once per frame
    void Start()
    {
        Vector2 forwardDirection = GameObject.Find("Player").GetComponent<PlayerController>().IsFacingRight() ? Vector2.right : Vector2.left;
        // prerobit aby sa strielalo vzhladom k natoceniu hraca
        rb.AddForce(forwardDirection * shotForce);
    }

    // pridat efekt zasahu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this, deletionTimeAfterHit);
    }
}
