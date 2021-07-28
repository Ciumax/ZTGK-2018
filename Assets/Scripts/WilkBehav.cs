using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilkBehav : MonoBehaviour {

    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private int spriteVersion = 0;
    public Transform[] patrolPoints;
    Transform currentPatrolPoint;
    public int currentPatrolIndex;
   // public float bulletspeed;
   // public float lifetime;
   // public float Timetoshoot;
    public float distance1;
    float TTS;
    public float MSpeed;
  //  public float PSpeed;
   // public GameObject bulletPrefab;
   // public GameObject Skad;
    public GameObject Cel;
    float Direction;
    private int HP;
    public int range;
  
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/wolf");
        if (patrolPoints.Length > 0)
        {
            currentPatrolIndex = 0;
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
       // TTS = Timetoshoot;
        HP = 2;

        

    }

    // Update is called once per frame
    void Update()
    {


        //if (Proximity(player, this.gameObject, 3)) { 

        if (Vector3.Distance(Cel.transform.position, transform.position) > 5f)
        {
            //  a = Vector3.Distance(transform.position, currentPatrolPoint.position);
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) > 0.3f)
            {

                transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint.position, 2 * Time.deltaTime);
            }
            else
            {
                if (currentPatrolIndex + 1 < patrolPoints.Length)
                {
                    currentPatrolIndex++;
                }
                else
                {
                    currentPatrolIndex = 0;
                }
                currentPatrolPoint = patrolPoints[currentPatrolIndex];
            }
        }
        //if ((player.transform.position-this.transform.position).sqrMagnitude > 1)
        //
        //{

        //  }
        /*Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x)* Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);*/


        if (Vector3.Distance(Cel.transform.position, transform.position) <= 5f)


        {
            //  a = Vector3.Distance(transform.position, currentPatrolPoint.position);
            distance1 = Vector3.Distance(Cel.transform.position, transform.position);
            if (HP <= 0)
            {

                
                Destroy(this.gameObject);
            }
            //Carts = Cel;
            //if (Carts.Length > 0) {
            GameObject closest = Cel;

            //	foreach (GameObject Cart in Carts) {

           // Timetoshoot -= Time.deltaTime;
            //	if (Cart != null) {
            float direction = Mathf.Atan2(closest.transform.position.y - transform.position.y, closest.transform.position.x - transform.position.x);
            if (!(Proximity(closest.gameObject, this.gameObject, 0)) && Proximity(closest.gameObject, this.gameObject, range * 2))
            {
                Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
                //ChangeSprite(dir);
                Direction = direction;
                print("Wilk biegnie w " + direction);
                transform.position = Vector3.MoveTowards(transform.position, Cel.GetComponent<Rigidbody2D>().position, 2 * Time.deltaTime);
                //this.GetComponent<Rigidbody2D>().AddForce(dir * MSpeed * 50);
            }
           
        }
        //	}
        // 	}
        ChangeSprite(Direction);
    }

    void ChangeSprite(float Dir)
    {
        if(Dir > 0 && Dir < 2)
            {
                spriteVersion = 2;

            }
        if (Dir < -3 )
        {
            spriteVersion = 3;

        }
        if (Dir < 0 &&  Dir >-1.5)
        {
            spriteVersion = 0;

        if (Dir <0.5 && Dir >-0.5)
            {
                spriteVersion = 1;

            }
        }
        spriteR.sprite = sprites[spriteVersion];

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            HP--;
            Debug.Log("-1 hp");
        }
        if (other.gameObject.tag == "Player")
        {
           // Destroy(other.gameObject);
           
            Debug.Log("Wilk zjadł");
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
    /*
    public GameObject GetClosest()
    {
        Carts = GameObject.FindGameObjectsWithTag("Cart");
        GameObject Closest;
		Closest = Carts [0];
		
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
    */
}


