using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour {
	PlayerInput _pi;
	Rigidbody _rb;

	Vector3 _newOrientation, _oldOrientation, _orientation;
	[SerializeField] float _timeRotationLerp = 0.00001f;
	float _deltaTime = 0;

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

	void Update() {
		if (_pi.IsHorizontalDown()) {
			if (_pi.GetHorizontal() > 0) {
				_newOrientation = Vector3.up * 90;
				_oldOrientation = transform.rotation.eulerAngles;
			}
			else {
				if (transform.rotation.eulerAngles.y < 90) {
					_oldOrientation = Vector3.up * (transform.rotation.eulerAngles.y + 360);
				}
				else {
					_oldOrientation = transform.rotation.eulerAngles;
				}
				_newOrientation = Vector3.up * 270;
			}

			_deltaTime = 0;
		}
		else if (_pi.IsVerticalDown()) {
			if (_pi.GetVertical() > 0) {
				if (transform.rotation.eulerAngles.y > 180) {
					_newOrientation = Vector3.up * 360;
				}
				else {
					_newOrientation = Vector3.zero;
				}
				_oldOrientation = transform.rotation.eulerAngles;
			}
			else {
				_newOrientation = Vector3.up * 180;
				_oldOrientation = transform.rotation.eulerAngles;
			}

			_deltaTime = 0;
		}
	}

	void FixedUpdate() {
		if (_deltaTime < _timeRotationLerp) {
			_deltaTime += Time.fixedDeltaTime;
			_orientation = Vector3.Lerp(_oldOrientation, _newOrientation, _deltaTime / _timeRotationLerp);
			_rb.MoveRotation(Quaternion.Euler(_orientation));
		}
	}
}
