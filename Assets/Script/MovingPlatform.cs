using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	private float speed = 5f;
	private float leftBound=0f, rightBound=0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		
		if(pos.x <= leftBound)
		{
			speed = Mathf.Abs(speed);
		}
		else if(pos.x>= rightBound)
		{
			speed = -Mathf.Abs(speed);
		}
	}

	void setBounds(Vector2 bounds){
		leftBound = bounds.x;
		rightBound = bounds.y;
	}
}
