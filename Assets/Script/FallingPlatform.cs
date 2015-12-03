using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
	//This is the script attached to the falling platforms
	bool isFalling = false;
	float downSpeed = 0f;
	//Function that fires when a game object collides with the collider
	void OnTriggerEnter(Collider collider){
		//If the colliding object has the tag "player"
		if (collider.gameObject.tag == "player") {
			//Set is falling boolean to true and cause this game object to be destroyed
			//after 10 seconds
			isFalling = true;
			Destroy (gameObject,10);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//If is falling boolean is true, meaning if the player has collided
		//with this object, then cause this object to slowly start moving downwards
		if (isFalling) {
			downSpeed += Time.deltaTime/3;
			transform.position=new Vector3(transform.position.x, transform.position.y-downSpeed, transform.position.z);
		}
	}
}
