using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour 
{
	private float score = 0.0f;
	private float score2 =0.0f;
	public Text scoreText;
	public bool test;
	private Transform lookAt;

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAt != null) {
			score++;

			if (score == 10) {
				test = true;

				score2++;
				score = 0;
			} else {
				test = false;
			}
			scoreText.text = ((int)score2).ToString ();
		} else {
			scoreText.text = ((int)score2).ToString ();
		}
	}
}
