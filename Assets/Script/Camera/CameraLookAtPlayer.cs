using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour {
	Transform _player;

	void Start() {
		_player = FindObjectOfType<PlayerInput>().transform;
		if (!_player) {
			Debug.LogError("Player not found to follow!");
		}
	}

	void Update() {
		transform.LookAt(_player);
	}
}
