using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	//This is the script for the explosion prefab
	// Use this for initialization
	void Start () {
		//Destroy the explosion particle effect two seconds after it is created
		Destroy (gameObject, 2);
	}
}
