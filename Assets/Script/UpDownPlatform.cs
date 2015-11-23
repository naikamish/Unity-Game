using UnityEngine;
using System.Collections;

public class UpDownPlatform : MonoBehaviour {
	bool isMoving = false;
	float topBound = 100f, bottomBound=0f, speed=25f;
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "player") {
			isMoving = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (isMoving) {
			pos.y += speed * Time.deltaTime;

			if (pos.y <= bottomBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.y >= topBound) {
				speed = -Mathf.Abs (speed);
			}
		}
		transform.position = pos;
	}
}
