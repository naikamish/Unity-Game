using UnityEngine;
using System.Collections;

public class Landmine : MonoBehaviour {
	private float speed = 2.5f;
	private float leftBound=0f, rightBound=0f;
	private float moveDirection=0;
	public GameObject explosion;
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
		leftBound = (Mathf.Floor(bounds.x/40f))*40f+10f;
		rightBound = leftBound+20f;
		moveDirection = bounds.z;
	}

	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
		}
		Destroy (gameObject);
	}
}
