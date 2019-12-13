using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabSystem : MonoBehaviour {
	InputManager _playerInput;

	bool _grabEvent;
	bool _isGrabbing;
	[SerializeField] int _vertDistance;
	[SerializeField] int _horizDistance;
	Collider _grabbingObject;
	Hashtable _objTable = new Hashtable();
	GameObject _objToBeGrabbed;


	void Start() {
		_playerInput = FindObjectOfType<InputManager>().GetComponent<InputManager>();
		_vertDistance = 3;
		_isGrabbing = false;
	}

	void Update() {
		_objToBeGrabbed = (GameObject)_objTable["Item"];
		if (_playerInput.GetInteract()) {
			_grabEvent = true;
			if (_isGrabbing) {
				_grabbingObject.transform.SetParent(null);
				_grabbingObject.GetComponent<Rigidbody>().isKinematic = false;
				_isGrabbing = false;
				_grabbingObject = null;
			}
			else if (_objToBeGrabbed != null) {
				if (_objToBeGrabbed.layer == 10) {
					_objToBeGrabbed.transform.SetParent(transform);
					_objToBeGrabbed.transform.Translate((Vector3.up * (_vertDistance)) + (Vector3.forward * (_horizDistance)));
					_objToBeGrabbed.GetComponent<Rigidbody>().isKinematic = true;
					_isGrabbing = true;
					_grabbingObject = _objToBeGrabbed.GetComponent<Collider>();
				}
			}
		}
		else if (_grabEvent) {
			_grabEvent = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (!_objTable.ContainsKey(other.gameObject.name) && other.gameObject.layer == 10) {
			_objTable.Add(other.gameObject.name, other.gameObject);
		}
	}
	void OnTriggerExit(Collider other) {
		if (_objTable.ContainsKey(other.gameObject.name)) {
			_objTable.Remove(other.gameObject.name);
		}
	}

	public bool IsGrabbing() {
		return _isGrabbing;
	}
}
