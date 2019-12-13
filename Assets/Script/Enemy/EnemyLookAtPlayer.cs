using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour {
	Transform _player;
	Rigidbody _rb;
	[SerializeField] float _velocity = 0;

	void Start() {
		_rb = GetComponent<Rigidbody>();
		_player = FindObjectOfType<PlayerMovement>().transform;
		if (!_player) {
			Debug.LogError("Player not found to follow!");
		}
	}

	void Update() {
		transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
	}
}
