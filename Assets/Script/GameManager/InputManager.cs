﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	float _horizontal, _vertical, _cameraC;
	bool _action, _jump;

	// Em Edit >> Project Settings... >> Script Execution Order, foi colocado para ser executado antes de todos.
	void Update() {
		// Tempo que leva para atingir valor máximo pode ser ajustado em Edit >> Project Settings... >> Input.
		// A (-1) <-> D (1).
		_horizontal = Input.GetAxis("Horizontal");
		// S (-1) <-> W (1).
		_vertical = Input.GetAxis("Vertical");
		// left (-1) <-> right (1).
		_cameraC = Input.GetAxis("CameraC");

		_action = Input.GetButtonDown("Action");
		_jump = Input.GetButtonDown("Jump");
	}

	public float GetHorizontal() {
		return _horizontal;
	}

	public float GetVertical() {
		return _vertical;
	}

	public float GetCameraC() {
		return _cameraC;
	}

	public bool GetAction() {
		return _action;
	}

	public bool GetJump() {
		return _jump;
	}
}