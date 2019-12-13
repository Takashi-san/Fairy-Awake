using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPigVanishment : MonoBehaviour {
	[SerializeField] PlayerGrabSystem _grabSystem;
	[SerializeField] GameObject _pig;

	void Start() {
		//_grabSystem = gameObject.GetComponent<PlayerGrabSystem>();
		if (!_grabSystem) {
			Debug.Log("no grabsystem");
		}
	}

	void Update() {
		if (_grabSystem.IsGrabbing()) {
			if (!_pig.activeSelf) {
				_pig.SetActive(true);
			}
		}
		else if (_pig.activeSelf) {
			_pig.SetActive(false);
		}
	}
}
