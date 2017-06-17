using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveVector;

	public float speed = 5.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 18.0f;
	public bool pantat;
	public float jumpSpeed = 200.0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = Vector3.zero;

		// Inisialisasi mengambil variable dari Class Score
		GameObject score = GameObject.Find ("Score");
		Score budi = score.GetComponent<Score> ();

		pantat = budi.test;

		if(pantat == true){
			speed += 0.10f;
		}

		if (controller.isGrounded) {
			verticalVelocity = -0.5f;

			//untuk jump
			if (Input.GetKeyDown (KeyCode.Space)) {
				float ground = moveVector.y;
				float counter;

				for (counter = ground; counter < jumpSpeed; counter++) {
					verticalVelocity += 2.00f * Time.deltaTime;
				}
			}


			// X - left and Right
			moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		}
		else 
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}


		// Y - Up and Down


		moveVector.y = verticalVelocity;

		// Z - Forward and Backward
		moveVector.z = speed;

		controller.Move (moveVector * Time.deltaTime);

	}

	// Fungsi yang akan jalan ketika collision
	void OnControllerColliderHit(ControllerColliderHit hit){
		float melanin = speed * 20/100;

		if (hit.collider.gameObject.tag == "Enemy") {
			if (speed != 0) {
				speed -= melanin;
			} else if (speed <= 0) {
				speed = 0;
			}
				
		}
	}
}
