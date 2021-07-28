using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainsBehav : MonoBehaviour {
    int Timer;
	// Use this for initialization
	void Start () {
        Timer = 500;
	}
	
	// Update is called once per frame
	void Update () {
        Timer--;
        if (Timer < 0)
            Destroy(this);
	}
}
