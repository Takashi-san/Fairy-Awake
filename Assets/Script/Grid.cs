using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public GameObject target;
	public GameObject structure;
	Vector3 _truePosition;
	[SerializeField] float _gridSize;

	void LateUpdate() {
		_truePosition.x = Mathf.Floor(target.transform.position.x / _gridSize) * _gridSize;
		_truePosition.y = Mathf.Floor(target.transform.position.y / _gridSize) * _gridSize;
		_truePosition.z = Mathf.Floor(target.transform.position.z / _gridSize) * _gridSize;

		structure.transform.position = _truePosition;
	}
}
