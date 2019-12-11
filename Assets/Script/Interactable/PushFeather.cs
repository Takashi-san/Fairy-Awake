using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushFeather : MonoBehaviour {
	InputManager _inputManager;
	Hashtable _rockTable = new Hashtable();

	[SerializeField] float _rockSpeed = 0;
	[SerializeField] float _rockMoveTime = 0;

	void Start() {
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
	}

	void Update() {
		if (_inputManager.GetInteract()) {
			float distance = 999;
			GameObject closestRock = null;
			foreach (DictionaryEntry entry in _rockTable) {
				GameObject rock = (GameObject)entry.Value;
				if (Vector3.Distance(rock.transform.position, transform.position) < distance) {
					closestRock = rock;
				}
			}

			if (closestRock) {
				Vector3 diff = closestRock.transform.position - transform.position;
				if (Mathf.Abs(diff.z) < Mathf.Abs(diff.x)) {
					closestRock.GetComponent<StoneMovement>().MoveStone(Vector3.right * (diff.x / Mathf.Abs(diff.x)) * _rockSpeed, _rockMoveTime);
				}
				else {
					closestRock.GetComponent<StoneMovement>().MoveStone(Vector3.forward * (diff.z / Mathf.Abs(diff.z)) * _rockSpeed, _rockMoveTime);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if ((other.gameObject.tag == "PushRock") && (!_rockTable.ContainsKey(other.gameObject.name))) {
			_rockTable.Add(other.gameObject.name, other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if ((other.gameObject.tag == "PushRock") && (_rockTable.ContainsKey(other.gameObject.name))) {
			_rockTable.Remove(other.gameObject.name);
		}
	}
}
