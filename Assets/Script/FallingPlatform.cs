using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
	bool isFalling = false;
	float downSpeed = 0f;
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "player") {
			isFalling = true;
			Destroy (gameObject,3);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling) {
			downSpeed += Time.deltaTime/2;
			transform.position=new Vector3(transform.position.x, transform.position.y-downSpeed, transform.position.z);
		}
	}
}
