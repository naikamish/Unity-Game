using UnityEngine;
using System.Collections;

public class MainMenuPlatform : MonoBehaviour {
	public GameObject movingPlatformPrefab;
	// Use this for initialization
	void Start () {
		GameObject movingPlatform1 = Instantiate (movingPlatformPrefab, new Vector3 (-10f, 0, 0), Quaternion.identity) as GameObject;
		movingPlatform1.SendMessage("setBounds", new Vector3 (-25f, -10f, 0f));
		movingPlatform1.transform.localScale = new Vector3(2.5f, 0.5f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
