using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
// not absolutely needed, good programming practice
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;
	public float jumpCount = 0;
	
	private CharacterController _charController;
	public GameObject cam;
	// Different game objects might want to use CharacterController
	
	void Start() {
		_charController = GetComponent<CharacterController>();
		Vector3 pos = transform.position;
		cam.transform.position = pos;
	}
	
	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);
		// Don't want diagonal movement going to fast
		
		movement.y = gravity;
		// Controls tilting. Set gravity to "0" if you want character to fly

		if (Input.GetKeyDown (KeyCode.Space)) {
			jumpCount = 60f;
		}

		if(jumpCount>0){
			movement.y+=jumpCount;
			jumpCount--;
		}

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}
}
