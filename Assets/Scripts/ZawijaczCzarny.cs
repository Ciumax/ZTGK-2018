using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZawijaczCzarny : MonoBehaviour
{

    public float maxGravDist;
    public float maxGravity;
    public int life;
    GameObject[] planets;

    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("BHole");
    }

    void FixedUpdate()
    {
        if(life<0)
            Destroy(this.gameObject);


        planets = GameObject.FindGameObjectsWithTag("BHole");
        foreach (GameObject planet in planets)
        {
            float dist = Vector3.Distance(planet.transform.position, transform.position);
            if (dist <= maxGravDist)
            {
                Vector3 v = planet.transform.position - transform.position;
                GetComponent<Rigidbody2D>().AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
            }
        }
        life--;
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		//if (other.gameObject.tag == "enviroment")
		//{
		Destroy(this.gameObject);
		//	Debug.Log("");
		//}
	}
}























/*
public GameObject meteor;
public GameObject[] cdziury;
public float force;
private Rigidbody2D rb;

public float dist;
private bool strzalain;
void Start()
{
    rb = GetComponent<Rigidbody2D>();
    cdziury = GameObject.FindGameObjectsWithTag("dziura");
}
void OnTriggerEnter2D(Collider2D meteor)
{
     strzalain = true;

}
void OnTriggerExit2D(Collider2D meteor)
{
    strzalain = false;
}

void Update()
{

    if (strzalain==true)
{

    Vector2 diff = meteor.transform.position - this.transform.position;
    rb.AddForce((diff).normalized * force);
    float angle = Mathf.Atan2(diff.x, diff.y);
    this.transform.rotation = Quaternion.AngleAxis(angle, transform.up);
}


}
private void FixedUpdate()
{

}
}
//Vector2.Distance(meteor.transform.position, this.transform.position) < dist */
