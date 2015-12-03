using UnityEngine;
using System.Collections;

public class Landmine : MonoBehaviour {
	//This is the script that controls the landmines
	private float speed = 2.5f;
	private float leftBound=0f, rightBound=0f;
	private float moveDirection=0;
	public GameObject explosion;

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		//If the landmine is moving in the x direction
		if (moveDirection == 0f) {
			pos.x += speed * Time.deltaTime;
			//Move the landmine within its x bounds
			if (pos.x <= leftBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.x >= rightBound) {
				speed = -Mathf.Abs (speed);
			}
		}
		//If the landmine is moving in the z direction
		else if (moveDirection == 1f) {
			pos.z += speed * Time.deltaTime;
			//Move the landmine within its z bounds
			if (pos.z <= leftBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.z >= rightBound) {
				speed = -Mathf.Abs (speed);
			}
		}
		
		transform.position = pos;
	}
	//Figure out the z direction and set the bounds of this object. This function
	//is called from the game manager when the object is created.
	void setBounds(Vector3 bounds){
		leftBound = (Mathf.Floor(bounds.x/40f))*40f+15f;
		rightBound = leftBound+10f;
		moveDirection = bounds.z;
	}
	//If the player collides with this object, cause the player to die
	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
		}
		Destroy (gameObject);
	}
}
