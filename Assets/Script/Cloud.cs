using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	public GameObject player, bombPrefab;
	float dx=0.1f;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		InvokeRepeating("DropBomb", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > transform.position.x) {
			dx = Mathf.Abs(dx);
		} 
		else if (player.transform.position.x < transform.position.x) {
			dx = -Mathf.Abs(dx);
		}

		pos.x += dx;
		transform.position = pos;
	}

	void DropBomb()
	{
		GameObject bomb = Instantiate(bombPrefab) as GameObject;
		bomb.transform.position = transform.position;
	}
}
