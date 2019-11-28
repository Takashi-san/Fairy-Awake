using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomChangeScene : MonoBehaviour {
	StageManager _stageManager;
	[SerializeField] string _stageName = "";

	void Start() {
		_stageManager = FindObjectOfType<StageManager>().GetComponent<StageManager>();
	}

	public void OnClick() {
		_stageManager.ChangeScene(_stageName);
	}
}
