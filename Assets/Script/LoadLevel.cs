using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	//This is the script to load a new scene
	public void LoadNewLevel (int level)
	{
		//Load the level that was passed as a parameter in the function
		Application.LoadLevel (level);
	}
}
