using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolnikBehav : MonoBehaviour {
    public Text MyText;
    public Image PoleTextu;
    public float time;
    public GameObject pieczlotych;
    public GameObject Daj;
    float settime;
    public bool Hata=false;
    bool first = true;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (Hata==false)
        {
            MyText.text = "O toż to wielki mag! Mógłbyś mi pomóc naprawić dziure w płocie? Ciagle przełażą przez nią wilki";
            PoleTextu.enabled = true;
           
        }
        if(Hata==true && first==true)
        {
            GameObject Clone;
            MyText.text = "Wielkie dzieki. Oto Twoja nagroda";
            PoleTextu.enabled = true;
            Clone = (Instantiate(pieczlotych, Daj.transform.position, transform.rotation)) as GameObject;
        }
        if(Hata==true && first==false)
        {
            GameObject Clone;
            MyText.text = "No dobrze masz jescze jedna, ale wiecej raczej nie mam...";
            PoleTextu.enabled = true;
            Clone = (Instantiate(pieczlotych, Daj.transform.position, transform.rotation)) as GameObject;
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {

        PoleTextu.enabled = false;


        MyText.text = "";
        if(Hata==true&& first==true)
            first = false;


    }
 
}
