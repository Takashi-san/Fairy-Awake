using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
	[SerializeField] Vector3 _offset = Vector3.zero;
	Transform _player;

	void Start() {
		_player = FindObjectOfType<PlayerMovement>().transform;
		if (!_player) {
			Debug.LogError("Player not found to follow!");
		}
	}

	void FixedUpdate() {
		transform.position = _player.position + _offset;
	}
}
