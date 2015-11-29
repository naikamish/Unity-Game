using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {
	float yBound=0f;
	float speed;
	// Use this for initialization
	void Start () {
		yBound = transform.position.y;
		speed = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		//deltaTime smooths out passage of time, it's the time between frames
		pos.y += speed * Time.deltaTime;
		transform.position = pos;
		
		if(pos.y < yBound-1)
		{
			speed = Mathf.Abs(speed);
		}
		else if(pos.y > yBound+1)
		{
			speed = -Mathf.Abs(speed);
		}
	}
}
