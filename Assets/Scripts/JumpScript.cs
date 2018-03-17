using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {

	public float jumpPower = 300f;

	Rigidbody rb;
	bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (isGrounded);
		if (Input.GetKey (KeyCode.Space) && isGrounded) {
			rb.AddForce (Vector3.up * jumpPower);
			isGrounded = false;
		}
	}

	void OnCollisionEnter(Collision collider){
		if (collider.contacts [0].normal.y > .7f) {
			isGrounded = true;
		}
	}

	void OnCollisionStay(Collision collider){
		if (collider.contacts [0].normal.y > .7f) {
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision collider){
		isGrounded = false;
	}
}
