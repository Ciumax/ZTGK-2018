using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public GameObject Wrog;
    float Timer;
    public float TimeToSpawn;
    public float SpawnLimit;
	// Use this for initialization
	void Start () {
        Timer = TimeToSpawn;
	}
	
	// Update is called once per frame
	void Update () {
		if (Timer <= 0 && SpawnLimit > 0)
        {
            Instantiate(Wrog, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            SpawnLimit--;
			Timer = TimeToSpawn;
        }
		Timer -= Time.deltaTime;
      //  if (SpawnLimit == 0)
      //      Destroy(this);
    }
}
