using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rigid;

    public float maxSpeed = 5f;
    public float acceleration = 35f;
    public AnimationCurve accelMultByDist;

	// Use this for initialization
	void Awake () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 velocity = rigid.velocity;
        InputDevice inputDevice = InputManager.ActiveDevice;
        float xInput = inputDevice.LeftStickX;
        float targetSpeed = xInput * maxSpeed;
        float xDiff = targetSpeed - velocity.x;
        float thisAccel = acceleration * accelMultByDist.Evaluate(Mathf.Abs(xDiff / maxSpeed));
        float xStep = Mathf.Sign(xDiff) * Mathf.Min(Mathf.Abs(xDiff), thisAccel * Time.deltaTime);
        velocity.x += xStep;
        rigid.velocity = velocity;
	}
}
