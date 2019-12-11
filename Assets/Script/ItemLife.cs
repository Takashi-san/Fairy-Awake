using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour {
	[SerializeField] int _heal = 0;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<PlayerHealth>().Heal(_heal);
			Destroy(gameObject);
		}
	}
}
