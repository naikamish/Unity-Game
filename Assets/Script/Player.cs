using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float delta, speed=10f, jumpCount, camDistance=50f;
	bool grounded;
	public GameObject cam;
	Vector3 pos;
	int rotated=0;
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		//cam.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 20);
		pos = transform.position;

		delta = Input.GetAxis ("Horizontal");

		if (rotated%4==0) {
			pos.x += delta * speed * Time.deltaTime;
			cam.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - camDistance);
		} 
		else if (rotated%4==1) {
			pos.z += delta * speed * Time.deltaTime;
			cam.transform.position = new Vector3 (transform.position.x+camDistance, transform.position.y, transform.position.z);
		}
		else if (rotated%4==2) {
			pos.x -= delta * speed * Time.deltaTime;
			cam.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z+camDistance);
		}
		else if (rotated%4==3) {
			pos.z -= delta * speed * Time.deltaTime;
			cam.transform.position = new Vector3 (transform.position.x-camDistance, transform.position.y, transform.position.z);
		}

		rotateGame ();
		jumpAction ();

		transform.position = pos;
	}

	void jumpAction(){
		if (Input.GetKeyDown (KeyCode.Space)&&grounded) {
			jumpCount = 30f;			
		}
		
		if(jumpCount>0){
			pos.y+=0.25f;
			jumpCount--;
		}
	}

	void rotateGame(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rotated++;
			cam.transform.Rotate (0,-90f,0);
		}
	}

	void OnTriggerEnter()
	{
		grounded = true;
	}
	void OnTriggerExit()
	{
		grounded = false;
	}
}