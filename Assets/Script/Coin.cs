using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	private int roty = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		roty++;
		Quaternion rotation = Quaternion.Euler(new Vector3(90,roty,90));
		transform.rotation = rotation;
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "player") {
			Destroy (gameObject);
		}
	}
}
