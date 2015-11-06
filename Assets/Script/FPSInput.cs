using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
// not absolutely needed, good programming practice
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;
	public float jumpCount = 0;
	public bool canJump = true;
	
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
	//	float deltaX = Input.GetAxis("Horizontal") * speed;
	//	float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(0, 0, 0);
		movement = Vector3.ClampMagnitude(movement, speed);
		// Don't want diagonal movement going to fast
		
		movement.y = gravity;
		// Controls tilting. Set gravity to "0" if you want character to fly

		if (Input.GetKeyDown (KeyCode.Space)&&canJump==true) {
			canJump=false;
			jumpCount = 30f;

		}

		if(jumpCount>0){
			movement.y+=jumpCount;
			jumpCount--;
		}

		Vector3 pos = transform.position;
		if (pos.y < 1&&jumpCount==0)
			canJump = true;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}

	void OnTriggerEnter(Collider collider){
		canJump = true;
	}

}
