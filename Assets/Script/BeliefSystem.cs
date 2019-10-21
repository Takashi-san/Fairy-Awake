using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeliefSystem : MonoBehaviour {
	[SerializeField] float _belief = 0;

	public void IncreaseBelief(float belief) {
		_belief += belief;
	}

	public void DecreaseBelief(float belief) {
		_belief -= belief;
	}

	public float GetBelief() {
		return _belief;
	}
}
