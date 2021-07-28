using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour {
	public string newLevel;
	public void onPlayButton()
	{
	//FindObjectOfType<audioManager> ().Play ("confirmSound");
	SceneManager.LoadScene(newLevel);
	}
	public void onRePlayButton()
	{
		FindObjectOfType<audioManager> ().Play ("confirmSound");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void onAuthorsButton()
	{
		FindObjectOfType<audioManager> ().Play ("confirmSound");

	}
	public void onBackButton()
	{
		FindObjectOfType<audioManager> ().Play ("confirmSound");
		SceneManager.LoadScene("Menu");
	}
	public void onQuitButton()
	{
		FindObjectOfType<audioManager> ().Play ("looserSound");	
	Application.Quit();
	}
}
