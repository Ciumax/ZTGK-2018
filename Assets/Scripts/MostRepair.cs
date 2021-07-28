using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostRepair : MonoBehaviour {
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    BoxCollider2D m_Collider;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/Most2v2");
        m_Collider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sand")
        {
            
            if (spriteVersion < 3)
                Destroy(other.gameObject);

            spriteVersion++;
            if (spriteVersion > 3)
                spriteVersion = 3;

            spriteR.sprite = sprites[spriteVersion];

            if (spriteVersion == 2)
            {
                m_Collider.size = new Vector3(1.7F, 1.0F, 0F);

            }
            if(spriteVersion == 3)
            {
                m_Collider.size = new Vector3(0.0F, 0.0F, 0F);
                this.gameObject.tag = ("Done");
            }
        }
    }
}
