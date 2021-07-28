using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public bool Proximity(GameObject a, GameObject b, float r){

		float v1 = Mathf.Pow(Mathf.Abs(a.transform.position.x - b.transform.position.x),2);
		float v2 = Mathf.Pow(Mathf.Abs(a.transform.position.y - b.transform.position.y),2);
		//float lng = Mathf.Sqrt(v1+v2);
		if( r >= Mathf.Sqrt(v1+v2))
			return true;
		else
			return false; 
	}
}