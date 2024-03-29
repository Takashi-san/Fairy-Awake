﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour {
	Rigidbody _rb;
	float _moveTime = 0;

	void Start() {
		_rb = gameObject.GetComponent<Rigidbody>();
	}

	public void MoveStone(Vector3 velocity, float moveTime) {
		_rb.constraints = RigidbodyConstraints.FreezeRotation;
		_moveTime = moveTime;
		_rb.velocity = velocity;
		StartCoroutine(StopStone());
	}

	IEnumerator StopStone() {
		yield return new WaitForSeconds(_moveTime);
		_rb.velocity = Vector3.zero;
		_rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
		yield break;
	}
}
