using UnityEngine;
using System.Collections;

public class RollingSpikeBall : MonoBehaviour {
	private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = new Vector3 (0, -9.8f, 10f);
		if(transform.position.y<-115f)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
			Destroy (gameObject);
		}
	}
}
