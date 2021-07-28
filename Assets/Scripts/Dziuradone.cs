using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dziuradone : MonoBehaviour {
    public string Info;
    public Text MyText;
    bool pomoc = true;
    public Image Myimage;
    GameObject[] Misja;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Misja = GameObject.FindGameObjectsWithTag("Objective");
        if (Misja.Length == 0)
        {
            pomoc = false;
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && pomoc==true)
        {
            MyText.text = Info;
            Myimage.enabled = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            MyText.text = "";
            Myimage.enabled = false;
        }


    }
}
