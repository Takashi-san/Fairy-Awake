using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFoward : MonoBehaviour {
	Rigidbody _rb;
	[SerializeField] float _velocity = 0;

	void Start() {
		_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		_rb.velocity = Vector3.zero;
		_rb.AddRelativeForce(Vector3.forward * _velocity, ForceMode.VelocityChange);
	}
}
