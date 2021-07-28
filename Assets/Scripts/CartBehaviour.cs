using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartBehaviour : MonoBehaviour {

	public float mSpeed;
	private int HP;
	void Start () {
		HP = 6;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (mSpeed * Time.deltaTime,Random.Range(-0.01f,0.01f), 0f));
		if (HP == 0)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Projectile") {
			Destroy (other.gameObject);
			HP--;
			Debug.Log ("-1 hp");
		}
	}

	
}
