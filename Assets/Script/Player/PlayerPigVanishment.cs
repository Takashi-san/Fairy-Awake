using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPigVanishment : MonoBehaviour {
	[SerializeField] PlayerGrabSystem _grabSystem;
	[SerializeField] GameObject _pig;
	[SerializeField] GameObject _flute;

	void Update() {
		if (_flute != null) {
			if (_flute.activeSelf) {
				_grabSystem = _flute.GetComponent<PlayerGrabSystem>();
				if (_grabSystem.IsGrabbing()) {
					if (!_pig.activeSelf) {
						_pig.SetActive(true);
					}
				}
				else if (_pig.activeSelf) {
					_pig.SetActive(false);
				}
			} else {
				_flute = null;
				_grabSystem = null;
			}
		}
	}
}