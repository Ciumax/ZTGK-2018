using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZachowanieMacieja : MonoBehaviour {
    public int TTS;
        int TTS2;
    public int bulletspeed;
    public GameObject Remains;
    public GameObject bulletPrefab;
    public GameObject Cel;
	// Use this for initialization
	void Start () {
        TTS2 = TTS;
	}
	
	// Update is called once per frame
	void Update () {
        TTS--;
        if (TTS == 0)
            FireBullet();
        if (TTS < 0)
            TTS = TTS2;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Strzalanatrola")
        {

            Destroy(other.gameObject);
            this.gameObject.tag = ("Done");
            Remains = (Instantiate(Remains, this.transform.position, this.transform.rotation)) as GameObject;
            Destroy(this.gameObject);
            
        }

    }
            public void FireBullet()
    {
        //Clone of the bullet
        GameObject closest = Cel;
        GameObject Clone;
        float randomness = (Random.Range(-1.8f, 0.8f));

        float direction = Mathf.Atan2(closest.transform.position.y - transform.position.y + randomness, closest.transform.position.x - transform.position.x + randomness);
        Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
        Vector3 d = new Vector3(dir.x, dir.y, 0);
        float ziom = direction * Mathf.Rad2Deg;
        print(ziom);
        Clone = (Instantiate(bulletPrefab, transform.position + d * 0.8f, transform.rotation)) as GameObject;
        //Clone = (Instantiate(bulletPrefab, Skad.transform.position + (d), transform.rotation)) as GameObject;
        Clone.transform.Rotate(Vector3.forward, angle: ziom - 270);
        Clone.GetComponent<Rigidbody2D>().AddForce(dir * bulletspeed);
		Destroy (Clone, 5);

    }
}
