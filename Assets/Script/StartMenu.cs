using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
	//This is the script for the start menu UI
	public Canvas instructionsMenu, controlsMenu;
	public Button instructionsButton, playButton, controlsButton;
	// Use this for initialization
	void Start () {
		//Get the instructions menu and controls menu canvas objects and make sure they are not visible at the start
		instructionsMenu = instructionsMenu.GetComponent<Canvas> ();
		controlsMenu = controlsMenu.GetComponent<Canvas> ();
		instructionsMenu.enabled = false;
		controlsMenu.enabled = false;
	}
	
	public void InstructionsPress(){
		//When the instructions button is pressed, open the instructions menu and disable all the other buttons
		instructionsMenu.enabled = true;
		instructionsButton.enabled = false;
		playButton.enabled = false;
		controlsButton.enabled = false;
	}
	
	public void ClosePress(){
		//When the close button in the instructions menu is pressed, disable the instructions menu and enable all other buttons
		instructionsMenu.enabled = false;
		instructionsButton.enabled = true;
		playButton.enabled = true;
		controlsButton.enabled = true;
	}

	public void ControlsPress(){
		//When the controls button is pressed, open the controls menu and disable all other buttons
		controlsMenu.enabled = true;
		instructionsButton.enabled = false;
		playButton.enabled = false;
		controlsButton.enabled = false;
	}

	public void ControlsClosePress(){
		//When the close button in the controls menu is pressed, disable the controls menu and enable all other buttons
		controlsMenu.enabled = false;
		instructionsButton.enabled = true;
		playButton.enabled = true;
		controlsButton.enabled = true;
	}
	
	public void PlayPress ()
	{
		//The the play button is pressed load scene 1
		Application.LoadLevel (1);
	}
}
