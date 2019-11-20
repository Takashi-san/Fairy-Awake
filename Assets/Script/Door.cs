using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	StageManager _stageManager;
	[SerializeField] string _stageName = "";
	[SerializeField] int _stageIndex = -1;

	void Start() {
		_stageManager = FindObjectOfType<StageManager>().GetComponent<StageManager>();
	}

	void OnCollisionEnter() {
		if (_stageIndex != -1) {
			_stageManager.ChangeScene(_stageIndex);
		}
		else {
			_stageManager.ChangeScene(_stageName);
		}
	}
}
