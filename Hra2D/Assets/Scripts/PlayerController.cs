using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedBasic = 5f;
    private float speedSprint = 8f;
    public float jumpForce = 300f;

    public float speed;
    private bool facingRight;

    public bool IsFacingRight() { return facingRight; }

    private Vector2 movement;
    private Rigidbody2D rb;
    private BoxCollider2D playerController;
    private GameObject barrel;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = speedBasic;
        facingRight = true;
        movement = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<BoxCollider2D>();
        barrel = GameObject.Find("Barrel");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        
        movement = new Vector2(horizontalMovement * speed, rb.velocity.y);

        if (horizontalMovement > 0 && !facingRight)
        {
            Turn();
        }
        else if (horizontalMovement < 0 && facingRight)
        {
            Turn();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            barrel.GetComponent<BarrelController>().Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speedSprint;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speedBasic;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer(movement);
    }

    private void MovePlayer(Vector2 movement)
    {
        rb.velocity = movement;
    }

    private bool IsOnGround()
    {
        // mozny kontakt s collidermi inych hernych objektov
        RaycastHit2D[] contacts = Physics2D.BoxCastAll(playerController.bounds.center, playerController.bounds.size, 0f, Vector2.down, 0.01f);
        
        int tmpCollisionCount = contacts.Length;
        for (int i = 0; i < tmpCollisionCount; i++)
        {
            RaycastHit2D tmpHit = contacts[i];
            
            // koliziu sameho so sebou vynechaj
            if (!tmpHit.collider.tag.Equals("Player"))
            {
                // ak si detegoval koliziu so zemou
                if (tmpHit.collider.tag.Equals("Ground"))
                {
                    return true;
                }
            }
        }
        
        // nedoslo ku kontaku so zemou
        return false;
    }

    private void Turn()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector2.up, 180f);
    }
}
