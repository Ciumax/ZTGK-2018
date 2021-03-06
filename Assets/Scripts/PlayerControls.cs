using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {
    public HPBar bar;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    public float mSpeed;
    public GameObject bullet1, bullet2, bullet3;
    public GameObject spell1, spell2, spell3;
    public GameObject Res;
    GameObject spell;
    GameObject bullet;
	public float cooldownTime;
	public float MovementcooldownTime = 0;
	float CurrentTime;
	int SpellCount;
	int mode;
	int modeValue;
    private int spriteVersion = 0;
    public Image EndImage;
	public Button Restart;
	public Button GoBackToMenu;
    int money;
    int wood;
    int stone;
	public int MaxEqu;
    int metal;
	public Text m_Text;
	public float HP;
    public float barMaxVal;
    public  float MP;
    GameObject[] Walls;
    public GameObject Remains;
    void Start () {
		
        spell = spell1;
        bullet = bullet1;
        barMaxVal = 100;
        HP=100;
        bar.fillAmount = HP / barMaxVal;
        Walls = GameObject.FindGameObjectsWithTag("Wall");
        SpellCount = 0;
         spell = Walls[SpellCount];
        wood = 2;
        stone = 1;
        metal = 1;
		CurrentTime = 0;
		mode = 1;
		modeValue = wood;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("Graphic/wizz");
        EndImage.enabled = false;
		Restart.gameObject.SetActive(false);
		GoBackToMenu.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		updateUI(m_Text);
        if (HP<= 0)
        {
			//FindObjectOfType<audioManager> ().Play ("looserSound");
            //this.GetComponent<SpriteRenderer>().sprite = Death;
            EndImage.enabled = true;
			Restart.gameObject.SetActive(true);
			GoBackToMenu.gameObject.SetActive(true);
            GetComponent<Camera>().transform.parent = null;
            Destroy(this.gameObject);
            Remains = (Instantiate(Remains, this.transform.position, this.transform.rotation)) as GameObject;
            
            
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * mSpeed * Time.deltaTime, 0f, 0f));
            MoveLeftRight(Input.GetAxisRaw("Horizontal"));
		}	
		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * mSpeed * Time.deltaTime, 0f));
            MoveUpDown(Input.GetAxisRaw("Vertical"));
		}
		if (Input.GetMouseButton(0) && Time.time>=CurrentTime) {
			
		//	print ("1");
			if (modeValue == wood && modeValue>0) {
            FireSpell();
			CurrentTime = Time.time + cooldownTime;
                modeValue--;
                
                
			} 
			else {
			print("brak surowca");
			}

		}
		if (Input.GetMouseButton(1) && Time.time>=CurrentTime)
        {
		//	print("2");
			if (modeValue > 0) {
				FireBullet ();
				CurrentTime = Time.time + cooldownTime;
				modeValue--;
			} else {
				print("brak surowca");
			}
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("wood");
			mode = 1;
			modeValue = wood;
            spell = spell1;
            bullet = bullet1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("stone");
			mode = 2;
			modeValue = stone;
          //  spell = spell2;
            bullet = bullet2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("gold");
			mode = 3;
			modeValue = metal;
           // spell = spell3;
            bullet = bullet3;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Lets Check this");
            
        }
        switch (mode) {
		case 1:
			wood = modeValue;
			break;
		case 2:
			stone = modeValue;
			break;
		case 3:
			metal = modeValue;
			break;


		}
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Projectile") {
			Destroy (other.gameObject);
			HP = HP - 10;
			bar.fillAmount = HP / barMaxVal;
           
			Debug.Log ("-10 hp");
		}
		if (other.gameObject.tag == "Fire")
			{
				Destroy(other.gameObject);
				HP=HP-5;
				bar.fillAmount = HP/ barMaxVal;

				Debug.Log("-5 hp from fire");
        }
        if (other.gameObject.tag == "FireWall")
        {
            Destroy(other.gameObject);
            HP = -210;
            bar.fillAmount = HP / barMaxVal;

            Debug.Log("-5000 hp from fire");
        }
        if (other.gameObject.tag == "Coin" && wood+metal+stone < MaxEqu)
        {
            Destroy(other.gameObject);
            metal++;
			if (mode == 3) {
				modeValue += 1;
			FindObjectOfType<audioManager>().Play("coinSound");
			}
            Debug.Log("Kaska wpadła");
        }
		if (other.gameObject.tag == "Sand" && wood+metal+stone < MaxEqu)
        {
            Destroy(other.gameObject);
            stone++;
			if (mode == 2) {
				modeValue += 1;
			}
			FindObjectOfType<audioManager>().Play("pickupSound");
            Debug.Log("Mniam kamyczki");
			Debug.Log(stone);
			Debug.Log(modeValue);
        }
		if (other.gameObject.tag == "Wood" && wood+metal+stone < MaxEqu)
        {
            Destroy(other.gameObject);
            wood++;
			if (mode == 1) {
				modeValue += 1;
			}
			FindObjectOfType<audioManager>().Play("pickupSound");
            Debug.Log("Czop czop");
			Debug.Log(wood);
			Debug.Log(modeValue);
        }
        if (other.gameObject.tag == "Wilk")
        {
            HP = -10;
        }
        // if (other.gameObject.tag == "Cywil")
        //     if (Input.GetKeyDown(KeyCode.E)

    }
    public void FireBullet() {
        GameObject Clone;
       
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float direction = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);

        //	Clone.transform.Rotate(0, 0, direction);
        Vector2 dir = new Vector2(mSpeed * Mathf.Cos(direction), mSpeed * Mathf.Sin(direction));
        Vector3 d = new Vector3(dir.x, dir.y, 0);
        float ziom = direction * Mathf.Rad2Deg;
        print(ziom);
        Clone = (Instantiate(bullet, transform.position + d * 0.2f, transform.rotation)) as GameObject;
       // mode--;
        //	Clone.transform.RotateAround(this.transform.position, Vector3.forward, ziom-90);///(Vector3.,ziom );
        Clone.transform.Rotate(Vector3.forward, angle: ziom - 90);
		FindObjectOfType<audioManager>().Play("bulletSound"); // tak robimy dzwięk
		print("bullet exist");
        Clone.GetComponent<Rigidbody2D>().AddForce(dir * 35);
       
        Destroy(Clone, 3);
        
        
        print("forceAddiction");

	
	}
   
   
	public void FireSpell(){
		GameObject Clone;
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Clone = (Instantiate(spell,mousePosition,transform.rotation)) as GameObject;
		print("Spell exist");
		//Destroy(Clone,5);
		FindObjectOfType<audioManager>().Play("blokSound");
		print("Casted");
		if (spell == Walls[0])
        {
           // wood--;
            print("metal poszedł i jest:"+metal);
        }
        else if(spell ==Walls[1])
        {
            wood--;
            print("drwien poszedłi jest:"+wood);
        }
        else if(spell==Walls[2])
        {
           // wood--;
            print("Kamien poszedł i jest:"+stone);
        }

	}
    void MoveUpDown(float x)
    {
        if (x > 0.5)
        {
         spriteVersion = 1;
        }
        if (x < 0.5)
        { 
        spriteVersion = 0;
         }
		if (MovementcooldownTime < Time.time) {
			FindObjectOfType<audioManager> ().Play ("stepSound");
			MovementcooldownTime = Time.time + 0.7f;
		}
        spriteR.sprite = sprites[spriteVersion];
    }
    void MoveLeftRight(float x)
    {
        if (x > 0.5)
        {
            spriteVersion = 2;
        }
        if (x < 0.5)
        {
            spriteVersion = 3;
        }
		if (MovementcooldownTime < Time.time) {
			FindObjectOfType<audioManager> ().Play ("stepSound");
			MovementcooldownTime = Time.time + 0.7f;
		}
        spriteR.sprite = sprites[spriteVersion];
    }
	void updateUI(Text m_Text){
		if (mode == 1)
		{
			m_Text.text = "Drewno:"+modeValue+"\nCałość " + (wood + metal + stone) + "/" + MaxEqu; 
		}
		else if (mode == 2)
		{
			m_Text.text = "Piasek:"+modeValue+"\nCałość " + (wood + metal + stone) + "/" + MaxEqu; 
		}
		else if (mode == 3)
		{
			m_Text.text = "Złoto:"+modeValue+"\nCałość " + (wood + metal + stone) + "/" + MaxEqu; 
		}

		//m_Text.text = +mode+":"+modeValue+"\nCałość " + (wood + metal + stone) + "/" + MaxEqu;     //"Drewno:" + wood + "\nPiasek:" + stone + "\nZłoto:" + metal + "\nCałość " + (wood + metal + stone) + "/" + MaxEqu;
	
	}
}

