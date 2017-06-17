using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMotor : MonoBehaviour {

	private float speed = 0.083f;
	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;
	private int speed2 = 0;
	private bool kiriKanan = false;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		moveVector = new Vector3();
		// X
		moveVector.x = 1.2f;

		//Y
		moveVector.y = 0.5f;

		moveVector.z = -2;
	}

	// Update is called once per frame
	void Update ()
	{
		if (counter == 200) {
			if (kiriKanan) {
				kiriKanan = false;
			} else {
				kiriKanan = true;
			}

			counter = 0;
		}

		if (kiriKanan) {
			moveVector.x += 0.01f;

			counter++;
		} else {
			moveVector.x -= 0.01f;

			counter++;
		}

		speed2++;
		if (speed > 0.299f) {
			speed = 0.299f;
		} else {
			if (speed2 == 70) {
				speed2 = 0;
				speed += 0.005f;
			}
		}


		moveVector.z += speed;

		transform.position = moveVector;
	}
}
