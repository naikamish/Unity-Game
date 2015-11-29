using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {
	bool isTriggered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();

		if(!isTriggered && target != null){
			isTriggered=true;
			target.SimulateDeath ();			
		}
	}
}
