using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehaviour : MonoBehaviour {

	//public SpawnPoint Spwner;
	public int condition;
	public string newLevel;
    GameObject[] Misja;
	// Use this for initialization
	void Start () {
       // Misja = GameObject.FindGameObjectsWithTag("Objective");
    }
	
	// Update is called once per frame
	void Update () 
	{
        Misja = GameObject.FindGameObjectsWithTag("Objective");
        if (Misja.Length == 0)
            condition = 0;
	}
	/*
	void OnTriggerEnter2D(Collider2D other){
					if (other.gameObject.tag == "Cart") {
					cartsDelivered++;
			Debug.Log ("Cart Delivered " + Spwner.SpawnLimit);
					Destroy (other.gameObject);
						
					} */
				//}
	void OnTriggerEnter2D(Collider2D other){
		if(condition == 0 && other.gameObject.tag == "Player"){
		//&& GameObject.FindGameObjectsWithTag ("Cart") == null
		Debug.Log ("Level Finished");
		//.Log ("Delivered"+cartsDelivered+"carts");
		SceneManager.LoadScene(newLevel);
	}


}
}
