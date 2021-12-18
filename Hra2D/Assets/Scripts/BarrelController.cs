using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    private float deletionTime;
    public float shotForce;     // force with which the bullet will be shot from barrel

    public float nextTimeToFire;
    public float fireRate;

    private void Awake()
    {
        fireRate = 1f;
        nextTimeToFire = 0f;
        shotForce = 350f;
        deletionTime = 5f;
    }

    public bool Shoot()
    {
        // This principle is inspired by video: https://www.youtube.com/watch?v=THnivyG0Mvo
        // Implements rate of fire for player and soldier
        if (Time.time >= nextTimeToFire)
        {
            GameObject tmp = Instantiate(projectile, transform.position, Quaternion.identity);

            tmp.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            Vector2 shotDirection = GetDirection();

            tmp.GetComponent<CircleCollider2D>().attachedRigidbody.AddForce(shotDirection * shotForce);

            nextTimeToFire = Time.time + 1 / fireRate;

            // Destroy bullet in case it won't hit anything
            Destroy(tmp, deletionTime);

            return true;
        }
        else {
            return false;
        }
    }

    // Get direction where barrel is pointing
    public Vector2 GetDirection()
    {
        string facing = transform.parent.rotation.eulerAngles.y == 180f ? "left" : "right";        

        bool facingLeft = transform.parent.rotation.eulerAngles.y == 180f;

        return facingLeft ? Vector2.left : Vector2.right;
    }
}
