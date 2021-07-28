using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pułapka : MonoBehaviour {

    public GameObject Cel, bulletPrefab;
     public int  bulletspeed,SetTTT;
    int TTT;
	void Start () {
        TTT = 0;
	}
	
	// Update is called once per frame
	void Update () {
        TTT--;
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && TTT<0)
        {
            FireBullet();
            TTT = SetTTT;


        }
    }
    public void FireBullet()
    {
        //Clone of the bullet
        GameObject closest = Cel;
        GameObject Clone;
        float randomness = (Random.Range(-0.1f, 0.1f));

        float direction = Mathf.Atan2(closest.transform.position.y - transform.position.y + randomness, closest.transform.position.x - transform.position.x + randomness);
        Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
        Vector3 d = new Vector3(dir.x, dir.y, 0);
        float ziom = direction * Mathf.Rad2Deg;
        print(ziom);
        Clone = (Instantiate(bulletPrefab, transform.position + d * 0.3f, transform.rotation)) as GameObject;
        //Clone = (Instantiate(bulletPrefab, Skad.transform.position + (d), transform.rotation)) as GameObject;
        Clone.transform.Rotate(Vector3.forward, angle: ziom - 270);
        Clone.GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed);
        Destroy(Clone, 5);

    }
}
