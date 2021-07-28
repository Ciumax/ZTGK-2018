using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundscrolling : MonoBehaviour {

	public GameObject player;
	public GameObject Twin;
	public float size;
	//Vector2 startPos = Twin.transform.position;

	void Start () {
		
	}
	void Update () {
		
		Vector2 startPos = Twin.transform.position;
		if (startPos.x >= player.transform.position.x -0.2f && startPos.x <= player.transform.position.x+0.2f) {
			print("half");
		if (startPos.x < player.transform.position.x) {
			transform.position = startPos + Vector2.right *size;
		}	
		else if (startPos.x > player.transform.position.x) {
				transform.position= startPos + Vector2.left*size;
		}	
		
	} 
}
}
