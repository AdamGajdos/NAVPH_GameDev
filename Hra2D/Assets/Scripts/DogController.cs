using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    public Vector2 movement = Vector2.zero;

    public bool facingRight = false;

    public Rigidbody2D rb;

    public Animator animator; 

    public GameObject player;

    public Collider2D playerCol;

    public Collider2D dogCollider;

    public float walkDist;

    public float runDist;

    public float attackDist;

    public float walkSpeed;

    public float runSpeed;

    public float damage;

    public float xDistBreak;

    private float realSpeed = 0f;

    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
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
        // float dist = Vector3.Distance(transform.position, player.transform.position);

        float dist = Physics2D.Distance(playerCol, dogCollider).distance;

        // float yDif = player.transform.position.y - transform.position.y;
        float xDif = player.transform.position.x - transform.position.x;


        // float yDist = Mathf.Abs(yDif);
        float xDist = Mathf.Abs(xDif);

        SetSpeed(dist, xDist);

        float horizontalMovement = 0;

        if (xDif != 0)
            horizontalMovement = (xDif) / Mathf.Abs(xDif);
       
        
        movement = new Vector2(horizontalMovement * realSpeed, rb.velocity.y);

        if ((horizontalMovement > 0 && !facingRight) || (horizontalMovement < 0 && facingRight))
            Turn();
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement * realSpeed));


        if (dist < attackDist){ 
            player.GetComponentInParent<Health>().HandleHit(damage); 
            animator.SetBool("Attack", true);
        }
        else{
            animator.SetBool("Attack", false);
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
