using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject movingPlatformPrefab, fallingPlatformPrefab;
	// Use this for initialization
	void Start () {
		GameObject movingPlatform = Instantiate (movingPlatformPrefab, new Vector3 (10, 0, 0), Quaternion.identity) as GameObject;
		movingPlatform.SendMessage ("setBounds", new Vector2(10f, 30f));
		GameObject movingPlatform2 = Instantiate (movingPlatformPrefab, new Vector3 (50, 0, 0), Quaternion.identity) as GameObject;
		movingPlatform2.SendMessage ("setBounds", new Vector2(50f, 62f));
		GameObject fallingPlatform = Instantiate (fallingPlatformPrefab, new Vector3 (70, 0, 0), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
