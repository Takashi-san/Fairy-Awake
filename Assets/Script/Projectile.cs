using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField] int _dmg = 0;
	[SerializeField] float _velocity = 0;
	[SerializeField] bool _enemy = false;
	[SerializeField] float _timeToDestroy = 0;
	float _timer = 0;

	void Start() {
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _velocity, ForceMode.VelocityChange);
	}

	void Update() {
		_timer += Time.deltaTime;
		if (_timer > _timeToDestroy) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (_enemy) {
			if (collider.gameObject.tag == "Player") {
				collider.gameObject.GetComponent<PlayerHealth>().Damage(_dmg);
			}
		}
		else {
			if (collider.gameObject.tag == "Enemy") {
				collider.gameObject.GetComponent<EnemyHealth>().Damage(_dmg);
				Destroy(gameObject);
			}
		}
	}
}
