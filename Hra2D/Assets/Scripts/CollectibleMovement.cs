using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMovement : MonoBehaviour
{
    public float start_position;

    void Start()
    {
        start_position = transform.position.y;
    }

    void Update()
    {
        // make collectible item floats up and down
        transform.position = new Vector3(transform.position.x, start_position + Mathf.Sin(2*Time.time) * 0.3f, transform.position.z);
    }

}
