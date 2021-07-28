using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBahaviour : MonoBehaviour
{
    GameObject[] Players;
    protected Transform trackingTarget;
    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    [SerializeField]
    protected float followSpeed;

    [SerializeField]
    protected bool isXLocked = false;

    [SerializeField]
    protected bool isYLocked = false;

 

    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
    }
   // void Update()
   // {
  //      transform.position = new Vector3(trackingTarget.position.x + xOffset,
  //          trackingTarget.position.y + yOffset, transform.position.z);
  //  }

    

    void Update()
    {
        int x = Players.Length;
        trackingTarget = Players[x-1].transform;
        //print("TO JEST PLAYER"+(x-1));
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        float xNew = transform.position.x;
        if (!isXLocked)
        {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }

        float yNew = transform.position.y;
        if (!isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }


}
/*
public float mSpeed;
void Start () {

}
void Update () {
    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
        transform.Translate (new Vector3 ( Input.GetAxisRaw ("Horizontal") * mSpeed * Time.deltaTime,0f, 0f));
    }	

}
}
*/
