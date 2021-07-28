using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DomRepair : MonoBehaviour {
     private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    GameObject rolnik;
    BoxCollider2D m_Collider;

    //  rolnik.GetComponent<RolnikBehav>().VariableName = 4;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/plotek2v2");
        rolnik = GameObject.FindGameObjectWithTag("Rolnik");
        m_Collider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wood")
        {
            if (spriteVersion < 3)
                Destroy(other.gameObject);

            spriteVersion++;
            if (spriteVersion > 3)
                spriteVersion = 3;

            spriteR.sprite = sprites[spriteVersion];
            
            this.gameObject.tag = ("Done");
            rolnik.GetComponent<RolnikBehav>().Hata=true;
            m_Collider.size = new Vector3(0.80F, 0.16F, 0F);
        }
    }
}
