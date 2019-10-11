using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	float _horizontal, _vertical;
	bool _horizontalDown, _verticalDown;

	void Update() {
		// A (-1) <-> D (1).
		_horizontal = Input.GetAxis("Horizontal");
		// S (-1) <-> W (1).
		_vertical = Input.GetAxis("Vertical");

		if (Input.GetButtonDown("Horizontal")) {
			_horizontalDown = true;
		}
		if (Input.GetButtonDown("Vertical")) {
			_verticalDown = true;
		}
	}

	public float GetHorizontal() {
		return _horizontal;
	}

	public bool IsHorizontalDown() {
		if (_horizontalDown) {
			_horizontalDown = false;
			return true;
		}
		return false;
	}

	public float GetVertical() {
		return _vertical;
	}

	public bool IsVerticalDown() {
		if (_verticalDown) {
			_verticalDown = false;
			return true;
		}
		return false;
	}
}
