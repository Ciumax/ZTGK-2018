using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Seba : MonoBehaviour {
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    public int mSpeed;
    bool go = false;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/SEBUŚ");
        
    }
	
	// Update is called once per frame
	void Update () {
        if(go==true)
        transform.Translate(Vector3.up * mSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            spriteVersion = 1;
            go = true;
            spriteR.sprite = sprites[spriteVersion];

        }



        }
    }
