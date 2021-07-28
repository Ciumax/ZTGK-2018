using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZgaśOgien : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sand")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            this.gameObject.tag = ("Done");
        }
    }
}
