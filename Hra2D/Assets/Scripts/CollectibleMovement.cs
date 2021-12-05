using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMovement : MonoBehaviour
{
    public float start_position;
    // Start is called before the first frame update
    void Start()
    {
        start_position = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, start_position + Mathf.Sin(2*Time.time) * 0.3f, transform.position.z);
    }

}
