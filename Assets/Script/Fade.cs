using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
	//This script is used to create a fading effect between scenes
	public Texture2D fadeOutTexture;
	float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI(){
		//Alpha is the transparency of the fade texture
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		//Clamps the alpha to a value between 0-1
		alpha = Mathf.Clamp01 (alpha);
		//Sets the GUI color to black
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		//Sets the GUI texture that covers the entire screen
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);

	}
	//This function will get called when a scene starts and ends and will slowly fade
	//in or out of the game
	public float BeginFade (int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}
	//Cause texture to fade in when level is loaded
	void OnLevelWasLoaded(){
		BeginFade (-1);
	}
}
