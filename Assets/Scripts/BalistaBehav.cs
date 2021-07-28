using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaBehav : MonoBehaviour {
    public GameObject Arrow;
    public GameObject From;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    public float bullet;
    private int spriteVersion = 0;
    int oneshot = 1;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/balistaaaaa");
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteVersion == 2 && oneshot == 1) {
            oneshot = 0;
        FireBullet();
    }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wood")
        {
            Destroy(other.gameObject);

            spriteVersion ++;
            if (spriteVersion > 2)
                spriteVersion = 2;
            spriteR.sprite = sprites[spriteVersion];

        }
    }
    public void FireBullet()
    {
        //Clone of the bullet
        // GameObject closest = GetClosest();
       // GameObject Clone;
        GameObject bullet = Instantiate(Arrow, From.transform.position, Quaternion.identity) as GameObject;
        bullet.transform.Rotate(Vector3.forward, angle: 180);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 5000);
       // float direction = Mathf.Atan2(Target.transform.position.y - transform.position.y, Target.transform.position.x - transform.position.x);
       // Vector2 dir = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));
       // Vector3 d = new Vector3(dir.x, dir.y, 0);
       // Clone = (Instantiate(Arrow, Target.transform.position + (d), transform.rotation)) as GameObject;
       // float ziom = direction * Mathf.Rad2Deg;
       // print(ziom);
      
       // Clone.GetComponent<Rigidbody2D>().AddForce(dir * 1);

    }
}
