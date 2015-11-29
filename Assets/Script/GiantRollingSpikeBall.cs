using UnityEngine;
using System.Collections;

public class GiantRollingSpikeBall : MonoBehaviour {
	private Rigidbody rigidbody;
	float speed = 15f;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x<=125f)
			speed = Mathf.Abs (speed);
		else if(transform.position.x>=250f)
			speed = -Mathf.Abs (speed);

		rigidbody.velocity = new Vector3 (speed, 0, 0);
	}
	
	void OnTriggerEnter(Collider collider){
		GameManager target = collider.gameObject.GetComponent<GameManager>();
		if (target != null) {
			target.SimulateDeath ();
			Destroy (gameObject);
		}
	}
}
