using UnityEngine;
using System.Collections;


public class HoldCharacter : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		collider.transform.parent = gameObject.transform;
	}

	void OnTriggerExit(Collider collider){
		collider.transform.parent = null;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
