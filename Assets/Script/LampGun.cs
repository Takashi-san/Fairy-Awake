using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampGun : MonoBehaviour {
	InputManager _inputManager;
	[SerializeField] GameObject _projectile;
	[SerializeField] float _fireRate = 0;
	[SerializeField] bool _triple = false;
	[SerializeField] int _tripleAngle = 0;
	float _fireTimer = 0;

	void Start() {
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();

		if (!_inputManager) {
			Debug.LogError("No InputManager found in the scene!");
		}
	}

	void Update() {
		_fireTimer += Time.deltaTime;
		if (_fireTimer >= _fireRate) {
			if (_inputManager.GetInteract()) {
				if (_triple) {
					TripleShoot();
				}
				else {
					Shoot();
				}

				_fireTimer = 0;
			}
		}
	}

	void Shoot() {
		Instantiate(_projectile, transform.position, transform.parent.rotation);
	}

	void TripleShoot() {
		Instantiate(_projectile, transform.position, transform.parent.rotation);
		Instantiate(_projectile, transform.position, Quaternion.Euler(transform.parent.rotation.eulerAngles - (Vector3.up * _tripleAngle)));
		Instantiate(_projectile, transform.position, Quaternion.Euler(transform.parent.rotation.eulerAngles + (Vector3.up * _tripleAngle)));
	}
}
