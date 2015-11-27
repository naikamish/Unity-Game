using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public Canvas instructionsMenu;
	public Button instructionsButton;
	public Button playButton;
	// Use this for initialization
	void Start () {
		instructionsMenu = instructionsMenu.GetComponent<Canvas> ();
		instructionsMenu.enabled = false;
	}
	
	public void InstructionsPress(){
		instructionsMenu.enabled = true;
		instructionsButton.enabled = false;
		playButton.enabled = false;
	}
	
	public void ClosePress(){
		instructionsMenu.enabled = false;
		instructionsButton.enabled = true;
		playButton.enabled = true;
	}
	
	public void PlayPress ()
	{
		Application.LoadLevel (1);
	}
}
