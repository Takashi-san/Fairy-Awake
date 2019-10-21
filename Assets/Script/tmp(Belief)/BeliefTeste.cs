using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeliefTeste : MonoBehaviour {
	BeliefSystem _beliefSystem;

	void Start() {
		_beliefSystem = FindObjectOfType<BeliefSystem>();
		if (!_beliefSystem) {
			Debug.LogError("No BeliefSystem found!");
		}
	}

	void Update() {
		transform.localScale = Vector3.one * (_beliefSystem.GetBelief() / 10f);
	}
}
