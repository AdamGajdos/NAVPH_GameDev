using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NabojKontroler : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float silaStrely = 350f;
    private float casNaZnicenie = 0.5f;

    // Update is called once per frame
    void Start()
    {

        Vector2 vpred = GameObject.Find("Hrac").GetComponent<Kontroler>().getSmerVpravo() ? Vector2.right : Vector2.left;
        // prerobit aby sa strielalo vzhladom k natoceniu hraca
        rb.AddForce(vpred * silaStrely);
    }

    // pridat efekt zasahu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this, casNaZnicenie);
    }
}
