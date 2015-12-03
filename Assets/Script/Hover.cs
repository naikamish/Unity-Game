using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {
	//This is the script used to cause objects to hover
	float yBound=0f;
	float speed;
	// Use this for initialization
	void Start () {
		yBound = transform.position.y;
		//Create a random speed for the hovering object
		speed = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		//deltaTime smooths out passage of time, it's the time between frames
		pos.y += speed * Time.deltaTime;
		transform.position = pos;
		//Move the hovering object up and down at the given speed within the bounds
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
