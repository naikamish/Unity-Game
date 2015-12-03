using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	//This is the script that controls the moving platform
	private float speed = 5f;
	private float leftBound=0f, rightBound=0f;
	private float moveDirection=0;
	public GameObject landMinePrefab;
	GameObject landMine;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;
		//If the game object is moving in the x direction
		if (moveDirection == 0f) {
			pos.x += speed * Time.deltaTime;
			//Move the game object within its bounds
			if (pos.x <= leftBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.x >= rightBound) {
				speed = -Mathf.Abs (speed);
			}
		}
		//If the game object is moving in the z direction
		else if (moveDirection == 1f) {
			pos.z += speed * Time.deltaTime;
			//Move the game object within its bounds
			if (pos.z <= leftBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.z >= rightBound) {
				speed = -Mathf.Abs (speed);
			}
		}
		transform.position = pos;
	}
	//Set the bounds of the game object and set its z direction
	//This function is called in the game manager when the object is created
	void setBounds(Vector3 bounds){
		leftBound = bounds.x;
		rightBound = bounds.y;
		moveDirection = bounds.z;
		//Instantiate a land mine with the same bounds as this game object
		landMine = Instantiate (landMinePrefab, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), Quaternion.identity) as GameObject;
		landMine.SendMessage ("setBounds", bounds);
	}
	//Destroy the land mine when this game object is destroyed
	void OnDestroy(){
		Destroy (landMine);
	}
}
