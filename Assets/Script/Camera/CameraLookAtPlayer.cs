using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour {
	Transform _player;
	[SerializeField] float _maxSqrOffset = 0;

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
