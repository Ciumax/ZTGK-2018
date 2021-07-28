using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BramaDungeon : MonoBehaviour {
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 3;
    BoxCollider2D m_Collider;
    GameObject[] Buttons;
    // Use this for initialization
    void Start()
    {
        Buttons = GameObject.FindGameObjectsWithTag("Button");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/brama2v2");
        m_Collider = GetComponent<BoxCollider2D>();
    }
    
	// Update is called once per frame
	void Update () {
        Buttons = GameObject.FindGameObjectsWithTag("Button");
        if(Buttons.Length<=0)
        {
            spriteVersion = 0;
            spriteR.sprite = sprites[spriteVersion];
            if (spriteVersion == 0)
            {
                m_Collider.size = new Vector3(0.0F, 0.0F, 0F);
                this.tag = "Done";

            }
        }
    }
}
