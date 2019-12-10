using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour {
	InputManager _inputManager;
	Rigidbody _rb;

	Vector3 _newOrientation, _oldOrientation, _orientation;
	[SerializeField] float _timeRotationLerp = 0.00001f;
	float _deltaTime = 0;

	void Start() {
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		_rb = gameObject.GetComponent<Rigidbody>();

		if (!_inputManager) {
			Debug.LogError("No InputManager found in the scene!");
		}
		if (!_rb) {
			Debug.LogError("No RigidBody in the object!");
		}
	}

	void FixedUpdate() {
		if (_inputManager.GetHorizontal() != 0) {
			if (_inputManager.GetHorizontal() > 0) {
				if (_newOrientation.y != 90) {
					_newOrientation = Vector3.up * 90;
					_oldOrientation = transform.rotation.eulerAngles;

					_deltaTime = 0;
				}
			}
			else {
				if (_newOrientation.y != 270) {
					if (transform.rotation.eulerAngles.y < 90) {
						_oldOrientation = Vector3.up * (transform.rotation.eulerAngles.y + 360);
					}
					else {
						_oldOrientation = transform.rotation.eulerAngles;
					}
					_newOrientation = Vector3.up * 270;

					_deltaTime = 0;
				}
			}
		}
		else if (_inputManager.GetVertical() != 0) {
			if (_inputManager.GetVertical() > 0) {
				if ((_newOrientation.y != 360) && (_newOrientation.y != 0)) {
					if (transform.rotation.eulerAngles.y > 180) {
						_newOrientation = Vector3.up * 360;
					}
					else {
						_newOrientation = Vector3.zero;
					}
					_oldOrientation = transform.rotation.eulerAngles;

					_deltaTime = 0;
				}
			}
			else {
				if (_newOrientation.y != 180) {
					_newOrientation = Vector3.up * 180;
					_oldOrientation = transform.rotation.eulerAngles;

					_deltaTime = 0;
				}
			}
		}


		// Do the lerping.
		if (_deltaTime < _timeRotationLerp) {
			_deltaTime += Time.fixedDeltaTime;
			_orientation = Vector3.Lerp(_oldOrientation, _newOrientation, _deltaTime / _timeRotationLerp);
			_rb.MoveRotation(Quaternion.Euler(_orientation));
		}
	}
}
