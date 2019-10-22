using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	PlayerInput _pi;
	Rigidbody _rb;

	[SerializeField] float _velocity = 0;
	[SerializeField] float _jumpVelocity = 0;

	void Start() {
		_pi = gameObject.GetComponent<PlayerInput>();
		_rb = gameObject.GetComponent<Rigidbody>();

		if (!_pi) {
			Debug.LogError("No PlayerInput in the object!");
		}
		if (!_rb) {
			Debug.LogError("No RigidBody in the object!");
		}
	}

	void FixedUpdate() {
		if (_pi.GetJump()) {
			_rb.velocity = Vector3.up * _jumpVelocity;
		}
		else {
			_rb.velocity = Vector3.up * _rb.velocity.y;
		}

		if (_pi.GetHorizontal() != 0) {
			_rb.velocity += Vector3.right * _pi.GetHorizontal() * _velocity;
		}
		else if (_pi.GetVertical() != 0) {
			_rb.velocity += Vector3.forward * _pi.GetVertical() * _velocity;
		}
		else {
			_rb.velocity += Vector3.zero;
		}
	}
}
