using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgienZabija : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Projectile")
        {

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "OwcaShot")
        {

            Destroy(other.gameObject);
        }
    }
}
