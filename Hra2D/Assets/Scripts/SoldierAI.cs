using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    public GameObject barrel;
    public Vector2 spotingArea;     // area where enemy gets spotted

    public float nextTimeToFire;
    public float fireRate;

    private void Awake()
    {
        spotingArea = new Vector2(26f, 3f);     // <-13f ; 13f> Horizontally  <-1.5f;1.5f> Vertically 
        nextTimeToFire = 0f;
        fireRate = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyDetected())
        {
            Shoot();
        }
    }

    public bool isEnemyDetected()
    {

        var detectedObjects = Physics2D.OverlapBoxAll(barrel.transform.position, spotingArea, 0f);

        foreach (var detectedObject in detectedObjects)
        {
            if (detectedObject.gameObject.tag.Equals("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void Shoot()
    {
        barrel.GetComponent<BarrelController>().Shoot();
    }
}
