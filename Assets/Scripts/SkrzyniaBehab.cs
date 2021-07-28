using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrzyniaBehab : MonoBehaviour
{
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    public GameObject tutaj;
    private int spriteVersion = 0;
    public GameObject coin;
    bool oneboi = false;
    // Use this for initialization
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/skrzynia");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"&& oneboi==false)
        {
            GameObject Clone;
            spriteVersion = 1;
            spriteR.sprite = sprites[spriteVersion];
            Clone = (Instantiate(coin, tutaj.transform.position, transform.rotation)) as GameObject;
            oneboi = true;
        }

    }
}
