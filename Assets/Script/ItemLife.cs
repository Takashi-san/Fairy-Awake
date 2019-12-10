using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour {
	[SerializeField] int _heal = 0;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<PlayerHealth>().Heal(_heal);
			Destroy(gameObject);
		}
	}
}
