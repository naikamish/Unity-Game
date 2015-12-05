using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > 0) {
			transform.position = new Vector3(100f,80f,40f);
		}
		else
			transform.position = new Vector3(100f,-10f,0);
	}
}