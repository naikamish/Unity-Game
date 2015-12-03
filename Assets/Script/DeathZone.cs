using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {
	//This is the script for the death zones that exist below the game screen
	bool isTriggered = false;

	void OnTriggerEnter(Collider collider){
		//Access the game manager script in the collided target
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		//If the game manager script exists, it must be the player
		//If the death zone has already been triggered, prevent it from killing
		//the player multiple times in a single collision
		if(!isTriggered && target != null){
			//Cause the player to die and isTriggered boolean to become true
			isTriggered=true;
			target.SimulateDeath ();			
		}
	}
}
