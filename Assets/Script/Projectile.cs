using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField] int _dmg = 0;
	[SerializeField] float _velocity = 0;
	[SerializeField] bool _enemy = false;

	void Start() {
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _velocity, ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider collider) {
		if (_enemy) {
			if (collider.gameObject.tag == "Player") {
				collider.gameObject.GetComponent<PlayerHealth>().Damage(_dmg);
			}
		}
		else {
			if (collider.gameObject.tag == "Enemy") {
				//collision.gameObject.GetComponent<PlayerHealth>().Heal(_heal);
				Destroy(gameObject);
			}
		}
	}
}
