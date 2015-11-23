using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y<-5)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
		}
		Destroy (gameObject);
	}
}
