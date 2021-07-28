using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPBar : MonoBehaviour
{

    public float fillAmount;
    public float e;
    public Image content;
    public float MaxValue { get; set; }
	
    public float Value
    {
        set
        {
            fillAmount = value;
        }
    }
   

	void Start () {
      //e= GameObject.Find("ThePlayer").GetComponent<PlayerControls>().HP ; 
    }
	
	// Update is called once per frame
	void Update () {
       // e = HP/100;
        HandleBar();
	}

    void HandleBar()
    {
        //  fillAmount = e;
        if (content.fillAmount != fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }
   
}
