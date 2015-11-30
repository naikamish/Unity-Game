using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public Canvas instructionsMenu, controlsMenu;
	public Button instructionsButton, playButton, controlsButton;
	// Use this for initialization
	void Start () {
		instructionsMenu = instructionsMenu.GetComponent<Canvas> ();
		controlsMenu = controlsMenu.GetComponent<Canvas> ();
		instructionsMenu.enabled = false;
		controlsMenu.enabled = false;
	}
	
	public void InstructionsPress(){
		instructionsMenu.enabled = true;
		instructionsButton.enabled = false;
		playButton.enabled = false;
		controlsButton.enabled = false;
	}
	
	public void ClosePress(){
		instructionsMenu.enabled = false;
		instructionsButton.enabled = true;
		playButton.enabled = true;
		controlsButton.enabled = true;
	}

	public void ControlsPress(){
		controlsMenu.enabled = true;
		instructionsButton.enabled = false;
		playButton.enabled = false;
		controlsButton.enabled = false;
	}

	public void ControlsClosePress(){
		controlsMenu.enabled = false;
		instructionsButton.enabled = true;
		playButton.enabled = true;
		controlsButton.enabled = true;
	}
	
	public void PlayPress ()
	{
		Application.LoadLevel (1);
	}
}
