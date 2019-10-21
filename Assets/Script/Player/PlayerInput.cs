using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	float _horizontal, _vertical;
	bool _horizontalDown, _verticalDown;
	bool _use, _tmp;

	// Em Edit >> Project Settings... >> Script Execution Order, foi colocado para ser executado antes de todos.
	void Update() {
		// Tempo que leva para atingir valor máximo pode ser ajustado em Edit >> Project Settings... >> Input.
		// A (-1) <-> D (1).
		_horizontal = Input.GetAxis("Horizontal");
		// S (-1) <-> W (1).
		_vertical = Input.GetAxis("Vertical");

		_use = Input.GetButtonDown("Jump");
		_tmp = Input.GetButtonDown("Fire1");
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

	public bool GetTmp() {
		return _tmp;
	}
}
