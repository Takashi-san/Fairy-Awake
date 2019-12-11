using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabSystem : MonoBehaviour {
	InputManager _playerInput;

	bool _grabEvent;
	bool _isGrabbing;
	int _grabHeight;
	Collider _grabbingObject;


	void Start() {
		_playerInput = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		_grabHeight = 1;
		_isGrabbing = false;
	}

	void Update() {
		if (_playerInput.GetGrab()) {
			_grabEvent = true;
			if (_isGrabbing) {
				_grabbingObject.transform.SetParent(null);
				_grabbingObject.GetComponent<Rigidbody>().isKinematic = false;
				_isGrabbing = false;
				_grabbingObject = null;
			}
		}
		else if (_grabEvent) {
			_grabEvent = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.layer == 10 && _grabEvent && !_isGrabbing) {
			other.transform.SetParent(transform);
			other.transform.Translate(Vector3.up * (_grabHeight));
			other.GetComponent<Rigidbody>().isKinematic = true;
			_isGrabbing = true;
			_grabbingObject = other;
		}
	}
	//TODO: grabbing duas vezes (o segundo comando de soltar ainda deixa o evento ativado para pegar o objeto novamente)
}
