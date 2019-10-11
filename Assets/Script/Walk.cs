using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
	PlayerInput _pi;
	Rigidbody _rb;

	Vector3 _newOrientation, _oldOrientation, _orientation;
	[SerializeField] float _timeRotationLerp = 0.00001f;
	float _deltaTime;

	[SerializeField] float _velocity = 0;

	void Start() {
		_pi = gameObject.GetComponent<PlayerInput>();
		_rb = gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		// velocity.
		if (_pi.GetHorizontal() != 0) {
			_rb.velocity = Vector3.right * _pi.GetHorizontal() * _velocity;
		}
		else if (_pi.GetVertical() != 0) {
			_rb.velocity = Vector3.forward * _pi.GetVertical() * _velocity;
		}
		else {
			_rb.velocity = Vector3.zero;
		}

		// orientation.
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
		if (_pi.IsVerticalDown()) {
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

		_deltaTime += Time.fixedDeltaTime;
		_orientation = Vector3.Lerp(_oldOrientation, _newOrientation, _deltaTime / _timeRotationLerp);
		_rb.MoveRotation(Quaternion.Euler(_orientation));
	}
}
