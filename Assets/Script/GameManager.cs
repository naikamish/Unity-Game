using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject movingPlatformPrefab, fallingPlatformPrefab, floatingIslandPrefab,
						upDownPlatformPrefab, deathZonePrefab, teleporterPrefab, workstationPrefab;
	public List<GameObject> gameObjects = new List<GameObject>();
	public float dist=40f, off=10f;
	private float timer=100f;
	public Text livesText, timerText;
	public static bool canMove = true;
	public int lives;
	private Rigidbody rigidbody;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		lives = 3;
		rigidbody = GetComponent<Rigidbody> ();
		CreateObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		timerText.text = "" + (int)timer;
		if (timer <= 0) {
			Die ();
		}
		if (transform.position.y < -150) {
			Die ();
		}
	}

	public void Die(){
		RecreateGame ();
	}

	void RecreateGame(){
		canMove = true;
		rigidbody.isKinematic = false;
		lives--;
		livesText.text = "Lives: " + lives;
		transform.position = new Vector3 (0, 5, 0);
		foreach(GameObject gObject in gameObjects){
			Destroy(gObject);
		}
		gameObjects = new List<GameObject>();
		CreateObjects ();
		timer = 100f;
	}
	public void SimulateDeath(){
		if (!(lives == 0)) {
			canMove = false;
			transform.parent = null;
			Vector3 posit = transform.position;
			posit.y += 1f;
			transform.position = posit;
			rigidbody.isKinematic = true;
			StartCoroutine (SlowDeath ());
		}
		else
			Application.LoadLevel (2);


	}

	private IEnumerator SlowDeath() {
		Instantiate(explosion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (0.3f);
		Die ();
	}

	public void WinGame(){
		StartCoroutine (WinGameCoroutine ());
	}

	private IEnumerator WinGameCoroutine(){
		float fadeTime = GameObject.Find ("Player").GetComponent<Fade> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (3);
	}

	void CreateObjects(){
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
		//Move in z direction


		/*************************
		 * Teleporter
		 *************************/
		gameObjects.Add(Instantiate (teleporterPrefab, new Vector3 (dist*2, -100f, dist*1), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject);
		gameObjects.Add(Instantiate (teleporterPrefab, new Vector3 (dist*4, 0f, 0f), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject);

		gameObjects[6].SendMessage ("addTeleporter", gameObjects[7]);
		gameObjects[7].SendMessage ("addTeleporter", gameObjects[6]);
		//gameObjects.Add(Instantiate (upDownPlatformPrefab, new Vector3 (80, 0, 90), Quaternion.identity) as GameObject);
		
		/*************************
		 * Falling Platforms
		 *************************/
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (70, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (90, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (100, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (110, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (120, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (130, 0, 0), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (140, 0, 0), Quaternion.identity) as GameObject);
		//GameObject fallingPlatform5 = Instantiate (fallingPlatformPrefab, new Vector3 (80, 0, 90), Quaternion.identity) as GameObject;
		gameObjects.Add(Instantiate (fallingPlatformPrefab, new Vector3 (80, 0, 90), Quaternion.identity) as GameObject);

		
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
		gameObjects.Add(Instantiate (floatingIslandPrefab, new Vector3 (dist*2, -100f, dist*1), Quaternion.identity) as GameObject);

		/*************************
		 * Death Zones
		 *************************/
		gameObjects.Add(Instantiate (deathZonePrefab, new Vector3 (125f, -20f, 30f), Quaternion.identity) as GameObject);
		gameObjects.Add(Instantiate (deathZonePrefab, new Vector3 (80f,-120f,80f), Quaternion.identity) as GameObject);

		/*************************
		 * Workstation
		 *************************/
		gameObjects.Add(Instantiate (workstationPrefab, new Vector3 (202f,0,0f), Quaternion.Euler(new Vector3(0, -90,0))) as GameObject);

	}
}
