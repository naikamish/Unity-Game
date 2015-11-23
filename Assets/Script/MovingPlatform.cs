using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	private float speed = 5f;
	private float leftBound=0f, rightBound=0f;
	private float moveDirection=0;
	public GameObject landMinePrefab;
	GameObject landMine;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if (moveDirection == 0f) {
			pos.x += speed * Time.deltaTime;
		
			if (pos.x <= leftBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.x >= rightBound) {
				speed = -Mathf.Abs (speed);
			}
		}

		else if (moveDirection == 1f) {
			pos.z += speed * Time.deltaTime;
			
			if (pos.z <= leftBound) {
				speed = Mathf.Abs (speed);
			} else if (pos.z >= rightBound) {
				speed = -Mathf.Abs (speed);
			}
		}

		transform.position = pos;
	}

	void setBounds(Vector3 bounds){
		leftBound = bounds.x;
		rightBound = bounds.y;
		moveDirection = bounds.z;
		landMine = Instantiate (landMinePrefab, new Vector3(transform.position.x,transform.position.y+1,transform.position.z), Quaternion.identity) as GameObject;
		landMine.SendMessage ("setBounds", bounds);
	}

	void OnDestroy(){
		Destroy (landMine);
	}
}
