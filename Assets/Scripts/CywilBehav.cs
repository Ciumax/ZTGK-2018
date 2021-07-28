using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CywilBehav : MonoBehaviour
{
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    int hp = 1;
    bool saved = false;
    // Use this for initialization
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/Cywil");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            {
               // if (spriteVersion < 1)
                    //  Destroy(other.gameObject);

                   // spriteVersion += 1;
                //if (spriteVersion > 1)
                    spriteVersion = 1;
                this.tag = ("Done");
                spriteR.sprite = sprites[spriteVersion];


            }
        }
    }
}
