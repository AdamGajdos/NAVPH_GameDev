using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    public Vector2 movement = Vector2.zero;

    public bool facingRight = false;

    public Rigidbody2D rb;

    public Animator animator; 

    public GameObject player;   // player to be attacked

    public Collider2D playerCol;

    public Collider2D dogCollider;

    public float walkDist;  // distance between player and dog when the dog starts walking

    public float runDist;   // distance between player and dog when the dog starts running 

    public float attackDist;    // distance when dog will bite the player 

    public float walkSpeed;

    public float runSpeed;

    public float damage;

    public float xDistBreak;    // x part of distance between dog and player when dog stops moving -- Player is above the dog/ is standing on the dog

    private float realSpeed = 0f;   // actual speed for movement

    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player?.GetComponent<Collider2D>();

        
    }

    void Update()
    {
        SetMovement();
    }

     private void FixedUpdate()
    {
        MoveDog(movement);
    }

    private void SetSpeed(float dist, float xDist)
    {   

        if (dist > walkDist || dist < attackDist || xDist < xDistBreak) {
            realSpeed = 0;
        } 
        else if (dist > runDist) {
            realSpeed = walkSpeed;
        }
        else {
            realSpeed = runSpeed;
        }

    } 

    private void SetMovement()
    {
        if (player != null) // Fix for: when player dies the console is printing null error
        {

            float dist = Physics2D.Distance(playerCol, dogCollider).distance;

            float xDif = player.transform.position.x - transform.position.x;

            float xDist = Mathf.Abs(xDif);

            SetSpeed(dist, xDist);

            float horizontalMovement = 0;

            if (xDif != 0)
                horizontalMovement = (xDif) / Mathf.Abs(xDif);
       
        
            movement = new Vector2(horizontalMovement * realSpeed, rb.velocity.y);

            // Turn the dog towards player
            if ((horizontalMovement > 0 && !facingRight) || (horizontalMovement < 0 && facingRight))
                Turn();
        
            // set correct animation for moving dog (standing/walking/running)
            animator.SetFloat("Speed", Mathf.Abs(horizontalMovement * realSpeed));

            // for animating attack
            if (dist < attackDist){ 
                player.GetComponentInParent<Health>().HandleHit(damage); 
                animator.SetBool("Attack", true);
            }
            else{
                animator.SetBool("Attack", false);
            }    
        }

    } 

    private void MoveDog(Vector2 movement)
    {
        rb.velocity = movement;
    }

    private void Turn()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector2.up, 180f);
    }

}
