using UnityEngine;
using System.Collections;


public class HoldCharacter : MonoBehaviour {
	//This is the script to turn a colliding object into a child object of the 
	//object that it collides with
	void OnTriggerEnter(Collider collider){
		collider.transform.parent = gameObject.transform;
	}
	void OnTriggerExit(Collider collider){
		collider.transform.parent = null;
	}
}
