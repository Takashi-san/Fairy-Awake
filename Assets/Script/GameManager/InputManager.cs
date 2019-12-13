using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	float _horizontal, _vertical, _cameraC;
	bool _action, _jump, _shoot, _grab;
	bool _interact, _jItem, _kItem, _lItem;
	StageManager _stageManager;

	void Start() {
		_stageManager = FindObjectOfType<StageManager>().GetComponent<StageManager>();
	}

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
		_shoot = Input.GetButtonDown("Shoot");
		_grab = Input.GetButtonDown("Grab");

		_interact = Input.GetKeyDown(KeyCode.E);
		_jItem = Input.GetKeyDown(KeyCode.J);
		_kItem = Input.GetKeyDown(KeyCode.K);
		_lItem = Input.GetKeyDown(KeyCode.L);

		if (Input.GetKeyDown(KeyCode.Escape)) {
			_stageManager.ChangeScene("TitleScreen");
		}
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

	public bool GetGrab() {
		return _grab;
	}

	public bool GetInteract() {
		return _interact;
	}

	public bool GetShoot() {
		return _shoot;
	}

	public bool GetJ() {
		return _jItem;
	}

	public bool GetK() {
		return _kItem;
	}

	public bool GetL() {
		return _lItem;
	}
}
