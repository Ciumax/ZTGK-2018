using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsBehav : MonoBehaviour {
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    public int hp;
    public int TTD;
    GameObject[] Enemies;
    public GameObject bullet;
    GameObject Cel;
    public int bulletspeed,TTS,Arrows;
    int zmiana = 0, TTD2; 
    bool czysty = true;
	// Use this for initialization
	void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/kolcowy");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hp <= 0 || Arrows==0)
        {
            Destroy(this.gameObject);
            
        }

        if (zmiana == 1 && TTS<0 && Arrows!=0)
        {
            
            Fire();
            TTS = 50;
        }
        if (zmiana == 3)
        {
            TTD--;
           
        }
        TTS--;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile" && zmiana != 1)
        {
            Destroy(other.gameObject);
            hp--;
            Debug.Log("-1 hp");
        }
		if (other.gameObject.tag == "fire")
		{
			Destroy(other.gameObject);
			hp-=5;
			Debug.Log("-5 hp plonacy mur");
		}
        if (other.gameObject.tag == "Wood" && zmiana != 1)
        {
            Destroy(other.gameObject);
            zmiana = 1;
            spriteVersion = 1;
            spriteR.sprite = sprites[spriteVersion];
            this.gameObject.tag = ("Cannon");
        }
        if (other.gameObject.tag == "Sand" && zmiana != 2)
        {
            zmiana = 2;
            Destroy(other.gameObject);
            spriteVersion = 2;
            spriteR.sprite = sprites[spriteVersion];
            this.gameObject.tag = ("Kolec");
        }
        if (other.gameObject.tag == "Enemy" && zmiana == 2)
        {
            hp--;
            //u wroga dmg
        }
        if (other.gameObject.tag == "Coin" && zmiana != 3)
        {
            zmiana = 3;
            Destroy(other.gameObject);
            spriteVersion = 3;
            spriteR.sprite = sprites[spriteVersion];
            this.gameObject.tag = ("Poker");
        }
    }
        void OnTriggerStay2D(Collider2D other)
        {
        if (other.gameObject.tag == "Enemy" && zmiana == 3)
        {
            
            TTD2 = TTD;
            if (TTD2 < 0)
                hp--;
        }

    }


    public void Fire()
    {
        //Clone of the bullet
        GameObject closest = GetClosest();
        GameObject Clone;
        
        float direction = Mathf.Atan2(closest.transform.position.y - transform.position.y, closest.transform.position.x - transform.position.x);
        Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
        Vector3 d = new Vector3(dir.x, dir.y, 0);
        float ziom = direction * Mathf.Rad2Deg;
        print(ziom);
        Clone = (Instantiate(bullet, transform.position + d * 1.0f, transform.rotation)) as GameObject;
        Clone.transform.Rotate(Vector3.forward, angle: ziom - 270);
        Clone.GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed);
        Arrows--;
    }

    void Poker()
    {

    }
    public GameObject GetClosest()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject Closest;
        Closest = Enemies[0];
        
        foreach (GameObject Cart in Enemies)
        {
            float dist = Vector3.Distance(transform.position, Enemies[0].transform.position);
            for (int i = 0; i < Enemies.Length; i++)
            {
                float curDist = Vector3.Distance(transform.position, Enemies[i].transform.position);
                if (curDist < dist)
                {
                    Closest = Enemies[i].gameObject;
                    dist = curDist;
                }
            }
        }


        return Closest;
    }
}
