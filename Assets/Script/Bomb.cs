using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y<-10)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider collider){
		Destroy (gameObject);
	}
}
