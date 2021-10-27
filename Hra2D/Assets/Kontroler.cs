using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontroler : MonoBehaviour
{
    private float rychlostNormal = 5f;
    private float rychlostSprint = 8f;
    public float silaSkoku = 300f;

    public float rychlost;
    private bool smerVpravo;

    public bool getSmerVpravo() { return smerVpravo; }

    private Vector2 posun;
    private Rigidbody2D rb;
    private BoxCollider2D mojCollider;
    private GameObject hlaven;

    // Start is called before the first frame update
    void Start()
    {
        rychlost = rychlostNormal;
        smerVpravo = true;
        posun = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        mojCollider = GetComponent<BoxCollider2D>();
        hlaven = GameObject.Find("Hlaven");
    }

    // Update is called once per frame
    void Update()
    {
        float vpred = Input.GetAxis("Horizontal");
        
        posun = new Vector2(vpred * rychlost, rb.velocity.y);

        if (vpred > 0 && !smerVpravo)
        {
            otoc();
        }
        else if (vpred < 0 && smerVpravo)
        {
            otoc();
        }

        if (Input.GetKeyDown(KeyCode.Space) && jeNaZemi())
        {
            rb.AddForce(Vector2.up * silaSkoku);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            hlaven.GetComponent<HlavenKontroler>().vystrel();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rychlost = rychlostSprint;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rychlost = rychlostNormal;
        }

    }

    private void FixedUpdate()
    {
        pohniSa(posun);
    }

    private void pohniSa(Vector2 posunutie)
    {
        rb.velocity = posunutie;
    }

    private bool jeNaZemi()
    {
        // mozny kontakt s collidermi inych hernych objektov
        RaycastHit2D[] kontakty = Physics2D.BoxCastAll(mojCollider.bounds.center, mojCollider.bounds.size, 0f, Vector2.down, 0.01f);
        
        int tmp_pocet_zrazok = kontakty.Length;
        for (int i = 0; i < tmp_pocet_zrazok; i++)
        {
            RaycastHit2D tmp_RH = kontakty[i];
            
            // koliziu sameho so sebou vynechaj
            if (!tmp_RH.collider.tag.Equals("Player"))
            {
                // ak si detegoval koliziu so zemou
                if (tmp_RH.collider.tag.Equals("Ground"))
                {
                    return true;
                }
            }
        }
        
        // nedoslo ku kontaku so zemou
        return false;
    }

    private void otoc()
    {
        smerVpravo = !smerVpravo;
        transform.Rotate(Vector2.up, 180f);
    }
}
