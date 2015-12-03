using UnityEngine;
using System.Collections;

public class MainMenuPlatform : MonoBehaviour {
	//This is the script that manages the intro and end menus
	public GameObject movingPlatformPrefab;
	// Use this for initialization
	void Start () {
		//Instantiate the moving platform on the intro and end menus
		GameObject movingPlatform1 = Instantiate (movingPlatformPrefab, new Vector3 (-10f, 0, 0), Quaternion.identity) as GameObject;
		movingPlatform1.SendMessage("setBounds", new Vector3 (-25f, -10f, 0f));
		movingPlatform1.transform.localScale = new Vector3(2.5f, 0.5f, 2.5f);
	}
}
