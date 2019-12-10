using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabSystem : MonoBehaviour {
	PlayerInput _playerInput;

	bool _grabEvent;

	void Start() {
		_playerInput = gameObject.GetComponentInParent<PlayerInput>();
		if (!_playerInput) {
			Debug.LogError("Missing PlayerInput in parent object");
		}
	}

	void Update() {
		if (_playerInput.GetGrab()) {
			_grabEvent = true;
		}
		else if (_grabEvent) {
			_grabEvent = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.layer == 10 && _grabEvent) {
			other.transform.SetParent(transform);
			other.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
