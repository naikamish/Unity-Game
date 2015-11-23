using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
	bool isFalling = false;
	float downSpeed = 0f;
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "player") {
			isFalling = true;
			Destroy (gameObject,10);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling) {
			downSpeed += Time.deltaTime/5;
			transform.position=new Vector3(transform.position.x, transform.position.y-downSpeed, transform.position.z);
		}
	}
}
