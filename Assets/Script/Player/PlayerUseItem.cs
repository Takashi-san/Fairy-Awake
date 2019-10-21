using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseItem : MonoBehaviour {
	BeliefSystem _beliefSystem;
	[SerializeField] float _beliefGain = 1;
	PlayerInput _pi;

	void Start() {
		_beliefSystem = FindObjectOfType<BeliefSystem>();
		if (!_beliefSystem) {
			Debug.LogError("No BeliefSystem found!");
		}

		_pi = gameObject.GetComponent<PlayerInput>();
		if (!_pi) {
			Debug.LogError("No PlayerInput found!");
		}
	}

	void Update() {
		if (_pi.GetUse()) {
			_beliefSystem.IncreaseBelief(_beliefGain);
		}

		if (_pi.GetTmp()) {
			_beliefSystem.DecreaseBelief(_beliefGain);
		}
	}
}
