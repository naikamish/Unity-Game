using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject movingPlatformPrefab, fallingPlatformPrefab, floatingIslandPrefab;
	public float dist=40f, off=10f;
	// Use this for initialization
	void Start () {
		GameObject movingPlatform = Instantiate (movingPlatformPrefab, new Vector3 (10, 0, 0), Quaternion.identity) as GameObject;
		movingPlatform.SendMessage ("setBounds", new Vector2(10f, 30f));
		GameObject movingPlatform2 = Instantiate (movingPlatformPrefab, new Vector3 (50, 0, 0), Quaternion.identity) as GameObject;
		movingPlatform2.SendMessage ("setBounds", new Vector2(50f, 62f));

		/*************************
		 * Falling Platforms
		 *************************/
		GameObject fallingPlatform = Instantiate (fallingPlatformPrefab, new Vector3 (70, 0, 0), Quaternion.identity) as GameObject;
		GameObject fallingPlatform2 = Instantiate (fallingPlatformPrefab, new Vector3 (90, 0, 0), Quaternion.identity) as GameObject;
		GameObject fallingPlatform3 = Instantiate (fallingPlatformPrefab, new Vector3 (100, 0, 0), Quaternion.identity) as GameObject;
		GameObject fallingPlatform4 = Instantiate (fallingPlatformPrefab, new Vector3 (110, 0, 0), Quaternion.identity) as GameObject;


		/*************************
		 * Floating Islands
		 *************************/
		GameObject floatingIsland = Instantiate (floatingIslandPrefab, new Vector3 (dist*0, 0, 0), Quaternion.identity) as GameObject;
		GameObject floatingIsland2 = Instantiate (floatingIslandPrefab, new Vector3 (dist*1, 0, 0), Quaternion.identity) as GameObject;
		GameObject floatingIsland3 = Instantiate (floatingIslandPrefab, new Vector3 (dist*2, 0, 0), Quaternion.identity) as GameObject;
		GameObject floatingIsland4 = Instantiate (floatingIslandPrefab, new Vector3 (dist*3, 0, 0), Quaternion.identity) as GameObject;
		GameObject floatingIsland5 = Instantiate (floatingIslandPrefab, new Vector3 (dist*4, 0, 0), Quaternion.identity) as GameObject;

		GameObject floatingIsland6 = Instantiate (floatingIslandPrefab, new Vector3 (dist*2, 0, dist*1), Quaternion.identity) as GameObject;
		GameObject floatingIsland7 = Instantiate (floatingIslandPrefab, new Vector3 (dist*3, 0, dist*1), Quaternion.identity) as GameObject;
		GameObject floatingIsland8 = Instantiate (floatingIslandPrefab, new Vector3 (dist*4, 0, dist*1), Quaternion.identity) as GameObject;
		GameObject floatingIsland9 = Instantiate (floatingIslandPrefab, new Vector3 (dist*5, 0, dist*1), Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
