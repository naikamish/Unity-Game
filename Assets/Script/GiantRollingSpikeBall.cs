using UnityEngine;
using System.Collections;

public class GiantRollingSpikeBall : MonoBehaviour {
	//This is the script for the giant rolling spike ball
	private Rigidbody rigidbody;
	float speed = 15f;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Set the bounds of the object
		if(transform.position.x<=125f)
			//Change direction of the object if it moves outside the bounds
			speed = Mathf.Abs (speed);
		else if(transform.position.x>=250f)
			speed = -Mathf.Abs (speed);
		//Add velocity to the game object
		rigidbody.velocity = new Vector3 (speed, 0, 0);
	}
	
	void OnTriggerEnter(Collider collider){
		//If the object that collides with the game object is the player,
		//then start the SimulatDeath function in the player
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
			Destroy (gameObject);
		}
	}
}
