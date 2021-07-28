using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDungeon : MonoBehaviour {
    bool on = false;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/button");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag == "Coin" && on==false)
        {
            spriteVersion = 1;

            spriteR.sprite = sprites[spriteVersion];
            on = true;
            this.gameObject.tag = ("Done");
           
            Destroy(other.gameObject);
        }


        }

    }
