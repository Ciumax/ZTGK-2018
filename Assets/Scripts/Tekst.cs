using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tekst : MonoBehaviour
{

    public string Info;
    public Text MyText;
    public Image Myimage;
	public string EntrySound;

    void Start()
    {

        //Text sets your text to say this message
        MyText.text = "";
        Myimage.enabled = false;
    }

    void Update()
    {
        //Press the space key to change the Text message


    }
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player") {
			FindObjectOfType<audioManager> ().Play (EntrySound);

		}
	}
    void OnTriggerStay2D(Collider2D other)
    {

         if (other.tag=="Player")
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
