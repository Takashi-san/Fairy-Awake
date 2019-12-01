using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	InputManager _inputManager;
	PlayerCentral _playerCentral;
	Rigidbody _rb;

	[SerializeField] float _velocity = 0;
	[SerializeField] float _jumpVelocity = 0;
	[SerializeField] float _forceHit = 0;
	bool _canJump = true;

	void Start() {
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		_rb = gameObject.GetComponent<Rigidbody>();
		_playerCentral = gameObject.GetComponent<PlayerCentral>();

		if (!_inputManager) {
			Debug.LogError("No InputManager found in the scene!");
		}
		if (!_rb) {
			Debug.LogError("No RigidBody in the object!");
		}
	}

	void FixedUpdate() {
		if (!_playerCentral.GetHitStun()) {
			if (_inputManager.GetJump() && _canJump) {
				_rb.velocity = Vector3.up * _jumpVelocity;
				_canJump = false;
			}
			else {
				_rb.velocity = Vector3.up * _rb.velocity.y;
			}

			if (_inputManager.GetHorizontal() != 0) {
				_rb.velocity += Vector3.right * _inputManager.GetHorizontal() * _velocity;
			}
			else if (_inputManager.GetVertical() != 0) {
				_rb.velocity += Vector3.forward * _inputManager.GetVertical() * _velocity;
			}
			else {
				_rb.velocity += Vector3.zero;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		// Colisão com camada "chao".
		if (collision.gameObject.layer == 9) {
			_canJump = true;
			_playerCentral.SetHitStun(false);
		}

		// Colisão com espinhos.
		if (collision.gameObject.tag == "Enemy") {

			Vector3 dir = collision.transform.position - transform.position;
			dir = -dir.normalized;
			if (dir.x == 0 && dir.z == 0) {
				dir.x = 0.5f;
			}
			_rb.velocity = dir * _forceHit;
		}
	}
}
