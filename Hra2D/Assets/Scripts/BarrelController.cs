using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    private float deletionTime = 5f; 

    public void Shoot()
    {
        GameObject tmp = Instantiate(projectile, this.transform.position, Quaternion.identity);

        tmp.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

        Destroy(tmp, deletionTime);
    }
}
