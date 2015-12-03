using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {
	//When the player collides with the terminal, cause the player to win the game
	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.WinGame ();
		}
	}
}
