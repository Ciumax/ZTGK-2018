using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehav : MonoBehaviour
{

    public Transform[] patrolPoints;
    Transform currentPatrolPoint;
    public int currentPatrolIndex;
    public float bulletspeed;
    public float lifetime;
    public float Timetoshoot;
    public float distance1;
    float TTS, TTS2;
    public float TTD;
    public float MSpeed;
    float temp;
   
    public float PSpeed;
    public GameObject bulletPrefab;
    public GameObject Skad;
     GameObject Cel;
    private GameObject brak;
    //public float a; //a to zmienna testowa
    //public GameObject Cart;
    private int HP;
    public int range;
     GameObject[] Carts;
    // Use this for initialization
    void Start()
    {
        HP = 15;
        //Cel = GameObject.FindGameObjectWithTag("Player");
        if (patrolPoints.Length > 0)
        {
            currentPatrolIndex = 0;
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
        TTS = Timetoshoot;
        

         Carts = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        Cel = FindClosestEnemy();
        TTD--;

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
            if (Carts.Length > 0) {
                GameObject closest = Cel;

                //	foreach (GameObject Cart in Carts) {

                Timetoshoot -= Time.deltaTime;
                //	if (Cart != null) {
                float direction = Mathf.Atan2(closest.transform.position.y - transform.position.y, closest.transform.position.x - transform.position.x);
                if (!(Proximity(closest.gameObject, this.gameObject, range)) && Proximity(closest.gameObject, this.gameObject, range * 2))
                {
                    Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
                    this.GetComponent<Rigidbody2D>().AddForce(dir * MSpeed * 50);
                }
                else if (Timetoshoot <= 1 && Proximity(closest.gameObject, this.gameObject, range))
                {
                    FireBullet();
                    Timetoshoot = TTS;
                }
            }
            //	}
            // 	}
        }
    }
    public void FireBullet()
    {
        //Clone of the bullet
        GameObject closest = Cel;
        GameObject Clone;
        float randomness = (Random.Range(-0.35f, 0.35f));
        
       float direction = Mathf.Atan2(closest.transform.position.y - transform.position.y+randomness, closest.transform.position.x - transform.position.x+randomness);
        Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
        Vector3 d = new Vector3(dir.x, dir.y, 0);
        float ziom = direction * Mathf.Rad2Deg;
        print(ziom);
        Clone = (Instantiate(bulletPrefab, transform.position + d * 0.7f, transform.rotation)) as GameObject;
        //Clone = (Instantiate(bulletPrefab, Skad.transform.position + (d), transform.rotation)) as GameObject;
        Clone.transform.Rotate(Vector3.forward, angle: ziom - 270);
        Clone.GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed);
        Destroy(Clone, lifetime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            HP--;
            Debug.Log("-1 hp");
        }
        if (other.gameObject.tag == "fire")
        {
            Destroy(other.gameObject);
            HP=HP-5;
            Debug.Log("-1 hp");
        }
        if (other.gameObject.tag == "Kolec")
        {

            HP--;
            Debug.Log("-1 hp");
        }
        if (other.gameObject.tag == "Poker")
        {
            temp = MSpeed;
            TTS2 = TTS;
            MSpeed = 0;
            TTS = 999999;


            Debug.Log("Gram se");
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Kolec" && TTD < 0)
        {

            HP--;
            TTD = 1000;
            Debug.Log("-1 hp");
        }



    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Poker")
        {
            MSpeed = temp;
            TTS = TTS2;


            Debug.Log("O Ty kurde");
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

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        GameObject brak=null;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
       // if (gos.Length != 0)
      //  {
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
      //  }
      //  else
      //      return brak;
    
    }
    
    public GameObject GetClosest()
    {
        Carts = GameObject.FindGameObjectsWithTag("Enemy");
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

}
