using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBehav : MonoBehaviour
{
    public int mSpeed;
    bool gora;

    // Use this for initialization
    void Start()
    {
        gora = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gora == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * mSpeed);
           
        }
        else if (gora == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * mSpeed);
           
        }

        //   transform.Translate(new Vector3(mSpeed * Time.deltaTime, Random.Range(-0.01f, 0.01f), 0f));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gora == true)
        {
            gora = false;
        }
        else if (gora == false)
        {
            gora = true;
        }


    }
}
