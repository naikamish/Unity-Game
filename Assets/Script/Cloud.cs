using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	//This is the script for the object that controls the spike balls that fall
	//from the sky and the small rolling spike balls
	public GameObject player, bombPrefab,rollingSpikeBallPrefab;
	float dx=0.1f, dz=0.1f, chanceOfBomb=.2f;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		//Invoke a repeating function that drops bombs
		InvokeRepeating("DropBomb", 2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//These conditionals control if x direction of the falling bombs,
		//causing them to move towards the player
		if (player.transform.position.x > transform.position.x) {
			dx = Mathf.Abs(dx);
		} 
		else if (player.transform.position.x < transform.position.x) {
			dx = -Mathf.Abs(dx);
		}

		//These conditionals control the z direction of the falling bombs
		//causing them to move towards the player
		if (player.transform.position.z > transform.position.z) {
			dz = Mathf.Abs(dz);
		} 
		else if (player.transform.position.z < transform.position.z) {
			dz = -Mathf.Abs(dz);
		}
		//This moves the cloud towards the player
		pos.x += dx;
		pos.z += dz;
		transform.position = pos;
	}

	void DropBomb()
	{
		//Creates a bomb if the randomly generated value is less than the chanceOfBomb value
		if (Random.value < chanceOfBomb) {
			//If the player is on the upper level, create the falling bombs
			if (player.transform.position.y > -20f) {
				GameObject bomb = Instantiate (bombPrefab) as GameObject;
				bomb.transform.position = transform.position;
			} 
			//If the player is on the lower level, create the rolling bombs
			else if (player.transform.position.y < -90f) {
				Instantiate (rollingSpikeBallPrefab, new Vector3 (80f, -100f, -75f), Quaternion.Euler (new Vector3 (0, 0, 0)));
			}
		}
	}
}
