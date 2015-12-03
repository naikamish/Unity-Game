using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	//This is the script for the spike ball that falls from the sky
	public GameObject explosion;
	// Update is called once per frame
	void Update () {
		//Destroy game object if its y position goes lower than -5
		if(transform.position.y<-5)
			Destroy (gameObject);
	}

	//This function gets called when an object enters the bombs collider trigger
	void OnTriggerEnter(Collider collider){
		//Get the GameManager script of the target that collided with the bomb
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		//If the target has a Game Manager script, which means if it is the player
		//then kill the player
		if (target != null) {
			target.SimulateDeath ();
		}
		Destroy (gameObject);
	}
}
