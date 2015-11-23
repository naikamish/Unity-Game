using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyCollected : MonoBehaviour {
	public Text gameText;
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "player") {
			gameText.color= Color.green;
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
