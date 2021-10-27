using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HlavenKontroler : MonoBehaviour
{
    [SerializeField]
    protected GameObject naboj;

    public void vystrel()
    {
        GameObject tmp = Instantiate(naboj, this.transform.position, Quaternion.identity);

        tmp.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

        Destroy(tmp, 10f);
    }
}
