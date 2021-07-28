using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject Player;
    GameObject[] Players;
    int Timer;
    public int TimeToSpawn;
    public int SpawnLimit;
    
    // Use this for initialization
    void Start()
    {
        Timer = TimeToSpawn;

    }

    // Update is called once per frame
    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        if (Players.Length<1)
        {
            Instantiate(Player, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
                      
            SpawnLimit--;
        }
        Timer--;
        if (Timer < 0)
            Timer = TimeToSpawn;

        if (SpawnLimit == 0)
            Destroy(this);
    }
}
