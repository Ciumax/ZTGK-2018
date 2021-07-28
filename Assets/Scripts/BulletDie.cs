using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour {
    public GameObject res;
    //
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDestroy()
    {
        GameObject res2;
        res2 = (Instantiate(res, transform.position , transform.rotation)) as GameObject;
    }
}
