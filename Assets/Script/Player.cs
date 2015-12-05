using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	//This is the script that controls the player movements
	private float delta, speed=10f, jumpCount, camDistance=30f, camY=5f;
	int setRotationTime = 30;
	int rotationTime;
	private bool grounded, isRotating = false;
	public GameObject cam, map;
	Vector3 pos, camPos;
	int rotated=0;
	public AudioClip jumpSound;
	private AudioSource source;
	public Image mapImage;

	float camCurrX, camCurrZ, camNewX, camNewZ, rotationAngle, deltaX, deltaZ, deltaRotation;

	void Start () {
		rotationTime = setRotationTime;
		source = GetComponent<AudioSource>();
	}
	
	// Fixed update is used to avoid jittery movement caused by normal update
	void FixedUpdate ()
	{
		//Prevent weirdness when making player the child of a platform
		if(transform.parent!=null)
			transform.localScale=new Vector3(1/transform.parent.localScale.x,1/transform.parent.localScale.y,1/transform.parent.localScale.z);
		else
			transform.localScale = new Vector3(1f,1f,1f);

		transform.rotation = Quaternion.identity;
		pos = transform.position;
		//If the character is not currently dying can move should be true
		if (GameManager.canMove) {
			delta = Input.GetAxis ("Horizontal");
			//If the camera is not currently rotating
			if (!isRotating) {
				//Move the player based on where the camera is facing
				if (rotated % 4 == 0) {
					//Moving left moves the player negatively in the x direction
					//Moving right moves the player positively in the x direction
					pos.x += delta * speed * Time.deltaTime;
					cam.transform.position = new Vector3 (transform.position.x, transform.position.y + camY, transform.position.z - camDistance);
				} else if (rotated % 4 == 1) {
					//Moving left moves the player negatively in the z direction
					//Moving right moves the player positively in the z direction
					pos.z += delta * speed * Time.deltaTime;
					cam.transform.position = new Vector3 (transform.position.x + camDistance, transform.position.y + camY, transform.position.z);
				} else if (rotated % 4 == 2) {
					//Moving left moves the player positively in the x direction
					//Moving right moves the player negatively in the x direction
					pos.x -= delta * speed * Time.deltaTime;
					cam.transform.position = new Vector3 (transform.position.x, transform.position.y + camY, transform.position.z + camDistance);
				} else if (rotated % 4 == 3) {
					//Moving left moves the player positively in the z direction
					//Moving right moves the player negatively in the z direction
					pos.z -= delta * speed * Time.deltaTime;
					cam.transform.position = new Vector3 (transform.position.x - camDistance, transform.position.y + camY, transform.position.z);
				}
				//Call the rotateGame function
				rotateGame ();
				//Call the fixed update jump action function
				jumpActionFixed();
				transform.position = pos;
			}
			//Call the rotateCamera function
			rotateCamera ();
		}
	}
	//Normal update function is used to ensure the player jumps correctly,
	//in fixed update the jump button doesn't always work correctly
	void Update(){
		jumpAction ();
		openMap();
	}

	void openMap(){
		if (Input.GetKeyDown (KeyCode.M)) {
			mapImage.enabled = !mapImage.enabled;
			map.SetActive(!map.activeSelf);
		}
	}

	void jumpAction(){
		//If the player is grounded and space bar is pressed, play the jump sound
		//and cause the player to jump
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			source.PlayOneShot(jumpSound,0.5f);
			jumpCount = 30f;
		}
	}
	//If jump count is greater than 0, move the player upwards
	void jumpActionFixed(){
		if(jumpCount>0){
			pos.y+=0.25f;
			jumpCount--;
		}
	}
	//If the up or down buttons are pressed rotate the game
	void rotateGame(){
		if (Input.GetAxis ("Vertical")!=0) {
			if(Input.GetAxis ("Vertical")>0){
				//If the up button is pressed
				///The rotated variable determines what phase of rotation the camera is in
				rotated++;
				rotationAngle=-90f;
			}
			else if(Input.GetAxis ("Vertical")<0){
				//If the down button is pressed
				if(!(rotated<=0)){
					rotated--;
				}
				else rotated+=3;
				rotationAngle=90f;
			}
			camCurrX = cam.transform.position.x;
			camCurrZ = cam.transform.position.z;
			//Set the new position you want the camera to end up in
			if (rotated%4==0) {
				camNewX=transform.position.x;
				camNewZ=transform.position.z-camDistance;
			} 
			else if (rotated%4==1) {
				camNewX=transform.position.x+camDistance;
				camNewZ=transform.position.z;
			}
			else if (rotated%4==2) {
				camNewX=transform.position.x;
				camNewZ=transform.position.z+camDistance;
			}
			else if (rotated%4==3) {
				camNewX=transform.position.x-camDistance;
				camNewZ=transform.position.z;
			}
			//Set all the starting and ending positions of the camera and its rotation
			rotationTime=setRotationTime;
			deltaX=(camNewX-camCurrX)/rotationTime;
			deltaZ=(camNewZ-camCurrZ)/rotationTime;
			deltaRotation=rotationAngle/rotationTime;
			//Set the isRotating boolean to true
			isRotating=true;
		}
	}

	void rotateCamera(){
		//If the isRotating boolean is true, move and rotate the camera slightly
		//towards its final position, this will continue getting called in the update
		//function until the camera has finished rotating
		if (isRotating) {
			if(rotationTime!=0){
				camPos = cam.transform.position;
				camPos.x+=deltaX;
				camPos.z+=deltaZ;
				cam.transform.position = camPos;
				cam.transform.Rotate (0,deltaRotation,0);
				rotationTime--;
			}
			else{
				//Once rotation time is finished and the camera is in its final
				//position, set isRotating to false
				isRotating=false;
			}
		}
	}

	void OnTriggerStay()
	{
		//When the collider is triggered, make grounded true so the player can jump
		grounded = true;
	}
	void OnTriggerExit()
	{
		//If the collider isn't triggered, make grounded false so the player can't jump
		grounded = false;
	}
}