using UnityEngine;
using System.Collections;

public class RollingSpikeBall : MonoBehaviour {
	//This is the script for the small rolling spike balls
	private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Set the velocity of the rolling spike ball to cause it to move on the platform
		rigidbody.velocity = new Vector3 (0, -9.8f, 10f);
		//If the spike ball falls off the platform, destroy it
		if(transform.position.y<-115f)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider collider){
		//If the object collides with the player, cause the player to die
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
			Destroy (gameObject);
		}
	}
}
