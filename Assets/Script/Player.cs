using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float delta, speed=10f, jumpCount, camDistance=50f, camY=5f;
	int setRotationTime = 30;
	int rotationTime;
	bool grounded, isRotating = false;
	public GameObject cam;
	Vector3 pos, camPos;
	int rotated=0;

	float camCurrX, camCurrZ, camNewX, camNewZ, rotationAngle, deltaX, deltaZ, deltaRotation;

	void Start () {
		rotationTime = setRotationTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Prevent weirdness when making player the child of a platform
		if(transform.parent!=null)
			transform.localScale=new Vector3(1/transform.parent.localScale.x,1/transform.parent.localScale.y,1/transform.parent.localScale.z);
		else
			transform.localScale = new Vector3(1f,1f,1f);

		transform.rotation = Quaternion.identity;

		pos = transform.position;

		delta = Input.GetAxis ("Horizontal");
		if (!isRotating) {
			if (rotated % 4 == 0) {
				pos.x += delta * speed * Time.deltaTime;
				cam.transform.position = new Vector3 (transform.position.x, transform.position.y + camY, transform.position.z - camDistance);
			} else if (rotated % 4 == 1) {
				pos.z += delta * speed * Time.deltaTime;
				cam.transform.position = new Vector3 (transform.position.x + camDistance, transform.position.y + camY, transform.position.z);
			} else if (rotated % 4 == 2) {
				pos.x -= delta * speed * Time.deltaTime;
				cam.transform.position = new Vector3 (transform.position.x, transform.position.y + camY, transform.position.z + camDistance);
			} else if (rotated % 4 == 3) {
				pos.z -= delta * speed * Time.deltaTime;
				cam.transform.position = new Vector3 (transform.position.x - camDistance, transform.position.y + camY, transform.position.z);
			}

			rotateGame ();
			jumpAction ();

			transform.position = pos;
		}

		rotateCamera ();
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
		if (Input.GetAxis ("Vertical")!=0) {
			if(Input.GetAxis ("Vertical")>0){
				rotated++;
				rotationAngle=-90f;
			}
			else if(Input.GetAxis ("Vertical")<0){
				rotated--;
				rotationAngle=90f;
			}
			camCurrX = cam.transform.position.x;
			camCurrZ = cam.transform.position.z;

			if (rotated%4==0) {
				camNewX=transform.position.x;
				camNewZ=transform.position.z-camDistance;

				//cam.transform.position = new Vector3 (transform.position.x, transform.position.y+camY, transform.position.z - camDistance);
			} 
			else if (rotated%4==1) {
				camNewX=transform.position.x+camDistance;
				camNewZ=transform.position.z;


				//cam.transform.position = new Vector3 (transform.position.x+camDistance, transform.position.y+camY, transform.position.z);
			}
			else if (rotated%4==2) {
				camNewX=transform.position.x;
				camNewZ=transform.position.z+camDistance;


				//cam.transform.position = new Vector3 (transform.position.x, transform.position.y+camY, transform.position.z+camDistance);
			}
			else if (rotated%4==3) {
				camNewX=transform.position.x-camDistance;
				camNewZ=transform.position.z;

				//cam.transform.position = new Vector3 (transform.position.x-camDistance, transform.position.y+camY, transform.position.z);
			}

			rotationTime=setRotationTime;
			deltaX=(camNewX-camCurrX)/rotationTime;
			deltaZ=(camNewZ-camCurrZ)/rotationTime;
			deltaRotation=rotationAngle/rotationTime;

			isRotating=true;
			//cam.transform.Rotate (0,-90f,0);
		}
	}

	void rotateCamera(){
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
				isRotating=false;
			}
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