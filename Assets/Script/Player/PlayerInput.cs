using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	float _horizontal, _vertical;
	bool _horizontalDown, _verticalDown;
	bool _use, _tmp, _jump, _grab;

	// Em Edit >> Project Settings... >> Script Execution Order, foi colocado para ser executado antes de todos.
	void Update() {
		// Tempo que leva para atingir valor máximo pode ser ajustado em Edit >> Project Settings... >> Input.
		// A (-1) <-> D (1).
		_horizontal = Input.GetAxis("Horizontal");
		// S (-1) <-> W (1).
		_vertical = Input.GetAxis("Vertical");

		_use = Input.GetButtonDown("Jump");
		_jump = Input.GetButtonDown("Jump");
		_tmp = Input.GetButtonDown("Fire1");
		_grab = Input.GetButtonDown("Grab");
	}

	public float GetHorizontal() {
		return _horizontal;
	}

	public float GetVertical() {
		return _vertical;
	}

	public bool GetUse() {
		return _use;
	}

	public bool GetJump() {
		return _jump;
	}

	public bool GetTmp() {
		return _tmp;
	}

	public bool GetGrab()
	{
		return _grab;
	}
}
