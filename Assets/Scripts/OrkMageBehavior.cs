using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkMageBehavior : MonoBehaviour {
    public float bulletspeed;
    public float lifetime;
    public float Timetoshoot;
    public float MSpeed;
	float SetTimeShoot;
    public GameObject bulletPrefab;
    public GameObject Skad;
    public GameObject Slabosc;
    public GameObject Target;
    //public GameObject Cart;
    public GameObject Remains;
    private int HP;
    public int range;
    GameObject[] Carts;
    //Sprite Death;
    // Use this for initialization
    void Start()
    {
      //  Death = Resources.Load<Sprite>("Graphic/Plask");
        //print(Death);
        HP = 2;
		SetTimeShoot = Timetoshoot;
		Timetoshoot = 0;
     //   Carts = GameObject.FindGameObjectsWithTag("Cart");

    }

    // Update is called once per frame
    void Update()
    {

        if (HP <= 0)
        {

            //this.GetComponent<SpriteRenderer>().sprite = Death;

            Remains = (Instantiate(Remains, this.transform.position  , this.transform.rotation)) as GameObject;
            Destroy(this.gameObject);

        }
       // Carts = GameObject.FindGameObjectsWithTag("Cart");
      //  if (Carts.Length > 0)
       // {
      //      GameObject closest = GetClosest();

       //     foreach (GameObject Cart in Carts)
         //   {

		Timetoshoot -= 1*Time.deltaTime;
                if (Target != null)
                {
                    float direction = Mathf.Atan2(Target.transform.position.y - transform.position.y, Target.transform.position.x - transform.position.x);
                    if (!(Proximity(Target.gameObject, this.gameObject, range)) && Proximity(Target.gameObject, this.gameObject, range * 3))
                    {
                        Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
                        this.GetComponent<Rigidbody2D>().AddForce(dir * MSpeed * 50);
                    }
                    else if (Timetoshoot <= 1 && Proximity(Target.gameObject, this.gameObject, range))
                    {
                        FireBullet();
					Timetoshoot = SetTimeShoot;
                    }
                }
            
        }
    //}

    public void FireBullet()
    {
        //Clone of the bullet
       // GameObject closest = GetClosest();
        GameObject Clone;

        float direction = Mathf.Atan2(Target.transform.position.y - transform.position.y, Target.transform.position.x - transform.position.x);
        Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
        Vector3 d = new Vector3(dir.x, dir.y, 0);
        Clone = (Instantiate(bulletPrefab, Skad.transform.position + (d), transform.rotation)) as GameObject;
        float ziom = direction * Mathf.Rad2Deg;
        print(ziom);
        Clone.transform.Rotate(Vector3.forward, angle: ziom - 90);
        Clone.GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            HP--;
            Debug.Log("-1 hp");
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

    public GameObject GetClosest()
    {
        Carts = GameObject.FindGameObjectsWithTag("Cart");
        GameObject Closest;
        Closest = Carts[0];

        foreach (GameObject Cart in Carts)
        {
            float dist = Vector3.Distance(transform.position, Carts[0].transform.position);
            for (int i = 0; i < Carts.Length; i++)
            {
                float curDist = Vector3.Distance(transform.position, Carts[i].transform.position);
                if (curDist < dist)
                {
                    Closest = Carts[i].gameObject;
                    dist = curDist;
                }
            }
        }


        return Closest;
    }
}
