using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTurn : MonoBehaviour {
	[SerializeField] Vector3 _offset = Vector3.zero;
	Transform _player;
	InputManager _inputManager;

	[SerializeField] float _angleOffset = 0;
	[SerializeField] float _angleSpeed = 1;

	void Start() {
		_player = FindObjectOfType<PlayerMovement>().transform;
		if (!_player) {
			Debug.LogError("Player not found to follow!");
		}

		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		if (!_inputManager) {
			Debug.LogError("No InputManager found!");
		}
	}

	void Update() {
		if (_inputManager.GetCameraC() != 0) {
			_angleOffset = _angleOffset - _angleSpeed * _inputManager.GetCameraC();
		}
	}

	void FixedUpdate() {
		transform.position = _player.position + Quaternion.Euler(0, _angleOffset, 0) * _offset;
	}
}
