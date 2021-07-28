using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBehav : MonoBehaviour {

    public float MSpeed;
    public GameObject Target;
    public GameObject MoneyTarget;
    private int HP;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    public int range;
    int przekupstwo;
    // Use this for initialization
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/MoneyBoi");
        przekupstwo = 2;
        HP = 4;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            HP--;
            Debug.Log("-1 hp");
        }
        if (other.gameObject.tag == "Coin")
        {
            if (przekupstwo > 0) {
                Destroy(other.gameObject);
                przekupstwo--;



            }
          

        }
    }
        // Update is called once per frame
        void Update()
        {
            if (HP <= 0)
                Destroy(this.gameObject);

        if (przekupstwo > 0)
        {




            float direction = Mathf.Atan2(Target.transform.position.y - transform.position.y, Target.transform.position.x - transform.position.x);
            if (!(Proximity(Target.gameObject, this.gameObject, range)) && Proximity(Target.gameObject, this.gameObject, range + 10))
            {
                Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
                this.GetComponent<Rigidbody2D>().AddForce(dir * MSpeed * 50);



            }
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (przekupstwo == 0) { 
            spriteVersion = 1;
            spriteR.sprite = sprites[spriteVersion];
               }
            //this.rigidbody.angularVelocity = Vector3.zero;
        }
        }
        public bool Proximity(GameObject a, GameObject b, float r)
        {

            float v1 = Mathf.Pow(Mathf.Abs(a.transform.position.x - b.transform.position.x), 2);
            float v2 = Mathf.Pow(Mathf.Abs(a.transform.position.y - b.transform.position.y), 2);
            float lng = Mathf.Sqrt(v1 + v2);
            if (r >= lng)
                return true;
            else
                return false;

        }


    }
