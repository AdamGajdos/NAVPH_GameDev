using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedBasic;
    public float speedSprint;
    public float jumpForce = 300f;
    public float deathFallDistance = -50f;

    public string characterName;
    public string playerName;
    // public int coins;
    public string achievedLevel;

    public float speed;
    private bool facingRight;

    public bool IsFacingRight() { return facingRight; }

    private Vector2 movement;
    private Rigidbody2D rb;
    private BoxCollider2D playerController;
    private GameObject barrel;

    public Energy energy;

    public float sprintEnergy;

    public Ammo ammo;

    public Animator animator; 
    
    private GameObject[] listGround;

    void Awake(){
        listGround = GameObject.FindGameObjectsWithTag("Ground");
    }

    void Start()
    {
        // basic initialization
        speed = speedBasic;
        facingRight = true;
        movement = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<BoxCollider2D>();
        barrel = GameObject.Find("Barrel");
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        
        movement = new Vector2(horizontalMovement * speed, rb.velocity.y);

        // Animate player
        if (IsOnGround())
            animator.SetFloat("Speed", Mathf.Abs(horizontalMovement * speed));
        else
            animator.SetFloat("Speed", 0);
            
        // Rotate player to the right direction(where he/she is facing)
        if (horizontalMovement > 0 && !facingRight)
        {
            Turn();
        }
        else if (horizontalMovement < 0 && facingRight)
        {
            Turn();
        }

        // if (isJumping) {
        //     Debug.Log("Jumping???");
        //     animator.SetFloat("Speed", 0);
        //     if (IsOnGround())
        //         isJumping = false;
        // }
        // else {
        //     animator.SetFloat("Speed", Mathf.Abs(horizontalMovement * speed));
        // }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
            
        // Shooting
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (ammo.value > 0 && barrel.GetComponent<BarrelController>().Shoot())
                ammo.Use();
        }


        // Sprinting section start
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (energy.HasEnergy())
                speed = speedSprint;
            else
                speed = speedBasic;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speedBasic;
        }

        // Sprinting section end


        // Check whether player has fallen
        if (transform.position.y <= deathFallDistance)
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer(movement);

        if (IsSprinting()){
            Debug.Log("Sprintuje");
            energy.Decrease(sprintEnergy);

            if (!energy.HasEnergy())
                speed = speedBasic;
        }
    }

     private bool IsSprinting()
    {
        return speed == speedSprint;
    }

    private void MovePlayer(Vector2 movement)
    {
        rb.velocity = movement;
    }

    // Check if player is touching ground. Using for jumping and animating purpose
    private bool IsOnGround()
    {
        /*
            foreach (GameObject obj in listGround){
                if (obj.GetComponent<Collider2D>() != null && Physics2D.Distance(playerController, obj.GetComponent<Collider2D>()).distance < 0.001)
                    return true;
            }
            return false;
        */

        // List all colliders that is interacting with player collider
        // second argument is size of box casted by us. We want it to be the same size as the player
        // last argument is the distance between casted box and other collider. If the distance between them is smaller then hit is registered 
        RaycastHit2D[] contacts = Physics2D.BoxCastAll(playerController.bounds.center, playerController.bounds.size, 0f, Vector2.down, 0.015f);

        int tmpCollisionCount = contacts.Length;
        for (int i = 0; i < tmpCollisionCount; i++)
        {
            RaycastHit2D tmpHit = contacts[i];

            // dont collide with yourself
            if (!tmpHit.collider.tag.Equals("Player"))
            {
                // if you are colliding with ground object
                if (tmpHit.collider.tag.Equals("Ground"))
                {
                    return true;
                }
            }
        }

        // you are not touching ground
        return false;
    }

    // Rotate player if his/her movement is different than their dirrection
    private void Turn()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector2.up, 180f);
    }

    // initialize saved player data
    public void InitializePlayer(PlayerData data)
    {
        characterName = data.characterName;
        playerName = data.playerName;
        gameObject.GetComponent<Ammo>().UpdateValue(data.ammo);
        gameObject.GetComponent<Money>().UpdateValue(data.money);
        gameObject.GetComponent<Health>().UpdateValue(data.health);
        gameObject.GetComponent<Energy>().UpdateValue(data.energy);
        achievedLevel = data.achievedLevel;
    }
}
