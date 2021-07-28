using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRepair : MonoBehaviour {
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
     BoxCollider2D m_Collider;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/RepairThisWAll");
        m_Collider = GetComponent<BoxCollider2D>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sand")
        {
			if(spriteVersion<2)
            Destroy(other.gameObject);
			
            spriteVersion += 1;
            if (spriteVersion > 2)
                spriteVersion = 2;

            spriteR.sprite = sprites[spriteVersion];

            if (spriteVersion == 2)
            {
                m_Collider.size = new Vector3(0.3F, 1.5F, 0F);
                this.gameObject.tag = ("Done");
            }

        }
    }
}
