using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	//This script controls the majority of the game objects as well as 
	//controls player deaths and UI information
	public GameObject movingPlatformPrefab, fallingPlatformPrefab, floatingIslandPrefab,
						deathZonePrefab, teleporterPrefab, workstationPrefab,
						giantRollingSpikeBallPrefab;
	//List where all the game objects will be stored
	private List<GameObject> gameObjects = new List<GameObject>();
	private float dist=40f, off=10f;
	private float timer=300f;
	//Text for all UI elements
	public Text livesText, timerText;
	public static bool canMove = true;
	public int lives;
	private Rigidbody rigidbody;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		lives = 3;
		rigidbody = GetComponent<Rigidbody> ();
		//Call function to create all the game objects
		CreateObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		//Decrease timer by 1 every 1 second
		timer -= Time.deltaTime;
		timerText.text = "" + (int)timer;
		//If the timer hits zero, kill the player and set timer back to 300
		if (timer <= 0) {
			SimulateDeath ();
			timer=300;
		}
		//If the player somehow avoids the death zones and falls too far down, kill the player
		if (transform.position.y < -150) {
			SimulateDeath ();
			transform.position = new Vector3(transform.position.x, transform.position.y+5, transform.position.z);
		}
	}
	//Prevent keyboard inputs while player is dying and prevent any movement
	public void SimulateDeath(){
		canMove = false;
		transform.parent = null;
		Vector3 posit = transform.position;
		posit.y += 1f;
		transform.position = posit;
		rigidbody.isKinematic = true;
		//Start coroutine to create explosion and kill player
		StartCoroutine (SlowDeath ());
	}

	private IEnumerator SlowDeath() {
		//Instantiate an explosion
		Instantiate(explosion, transform.position, Quaternion.identity);
		//Wait .3 seconds while explosion occurs
		yield return new WaitForSeconds (0.3f);
		//Cause player to die
		Die ();
		//If player has 0 lives, load the lose game scene
		if (lives == 0) {
			Application.LoadLevel (2);
		}
	}
	//When the Die function is called, call the RecreateGame function
	//This is actually a bit redundant
	public void Die(){
		RecreateGame ();
	}
	//This function resets all the necessary variables after the player dies
	void RecreateGame(){
		//Allow the player to move again
		canMove = true;
		//Make the players rigidbody not be kinematic
		rigidbody.isKinematic = false;
		//Decrease lives by 1
		lives--;
		livesText.text = "Lives: " + lives;
		//Place player back at start of game
		transform.position = new Vector3 (0,5,0);
		//Destroy all the game objects that were created
		foreach(GameObject gObject in gameObjects){
			Destroy(gObject);
		}
		gameObjects = new List<GameObject>();
		//Recreate all the game objects, this is done so that any falling platforms
		//that were destroyed will be reset
		CreateObjects ();
		//Restart timer
		timer = 300f;
	}

	public void WinGame(){
		//Start coroutine to win the game
		StartCoroutine (WinGameCoroutine ());
	}

	private IEnumerator WinGameCoroutine(){
		//Call the BeginFade function in the Fade script
		float fadeTime = GameObject.Find ("Player").GetComponent<Fade> ().BeginFade (1);
		//Wait until the fade is finished then load the win game scene
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (3);
	}

	void CreateObjects(){
		//This is the function to create all the important game objects and insert
		//them into a list
		/*************************
		 * Moving Platforms
		 *************************/
		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (10, 0, 0), Quaternion.identity) as GameObject);
		gameObjects[0].SendMessage("setBounds", new Vector3 (10f, 30f, 0f));

		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (50, 0, 0), Quaternion.identity) as GameObject);
		gameObjects[1].SendMessage ("setBounds", new Vector3 (50f, 62f, 0f));
		
		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (80f, 0f, 10f), Quaternion.identity) as GameObject);
		gameObjects[2].SendMessage ("setBounds", new Vector3 (10f, 30f, 1f));
		
		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (80f, 0f, 50f), Quaternion.identity) as GameObject);
		gameObjects[3].SendMessage ("setBounds", new Vector3 (50f, 70f, 1f));

		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (80f, -100f, 50f), Quaternion.identity) as GameObject);
		gameObjects[4].SendMessage ("setBounds", new Vector3 (50f, 70f, 1f));

		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (170, 0, 0), Quaternion.identity) as GameObject);
		gameObjects[5].SendMessage ("setBounds", new Vector3 (170f, 190f, 0f));

		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (85f, -100f, -40f), Quaternion.identity) as GameObject);
		gameObjects[6].SendMessage ("setBounds", new Vector3 (85f, 110f, 0f));

		gameObjects.Add(Instantiate (movingPlatformPrefab, new Vector3 (240f, -100f, -30f), Quaternion.identity) as GameObject);
		gameObjects[7].SendMessage ("setBounds", new Vector3 (-30f, -10f, 1f));

		/*************************
		 * Teleporter
		 *************************/
		gameObjects.Add(Instantiate (teleporterPrefab, new Vector3 (dist*6, -100f, dist*1), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject);
		gameObjects.Add(Instantiate (teleporterPrefab, new Vector3 (dist*4, 0f, 0f), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject);

		gameObjects[8].SendMessage ("addTeleporter", gameObjects[9]);
		gameObjects[9].SendMessage ("addTeleporter", gameObjects[8]);

		/*************************
		 * Death Zones
		 *************************/
		gameObjects.Add(Instantiate (deathZonePrefab, new Vector3 (125f, -20f, 30f), Quaternion.identity) as GameObject);
		gameObjects[10].transform.localScale = new Vector3(300f,1f,90f);
		gameObjects.Add(Instantiate (deathZonePrefab, new Vector3 (175f,-120f,0f), Quaternion.identity) as GameObject);
		gameObjects[11].transform.localScale = new Vector3(250f, 1f, 200f);
		/*************************
		 * Falling Platforms
		 *************************/
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (70, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (90, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (110, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (120, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (130, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (140, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (80, 0, 90), Quaternion.identity) as GameObject);

		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (240f, -100f, 10), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (240f, -100f, 20), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (240f, -100f, 30), Quaternion.identity) as GameObject);

		/*************************
		 * Floating Islands
		 *************************/
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*0, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*1, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*2, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*4, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*5, 0, 0), Quaternion.identity) as GameObject);


		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*2, 0, dist*1), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*2, 0, dist*2), Quaternion.identity) as GameObject);
		
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*2, -100f, dist*2), Quaternion.identity) as GameObject);

		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*4, -100f, -30), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*5, -100f, -30), Quaternion.identity) as GameObject);

		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*6, -100f, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*6, -100f, dist*1), Quaternion.identity) as GameObject);

		/*************************
		 * Workstation
		 *************************/
		gameObjects.Add (Instantiate (workstationPrefab, new Vector3 (202f, 0, 0f), Quaternion.Euler (new Vector3 (0, -90, 0))) as GameObject);

		/*************************
		 * Giant Rolling Spike Ball
		 *************************/
		gameObjects.Add (Instantiate (giantRollingSpikeBallPrefab, new Vector3 (125f, -100f, -40f), Quaternion.Euler (new Vector3 (270, 0, 0))) as GameObject);

	}
}
