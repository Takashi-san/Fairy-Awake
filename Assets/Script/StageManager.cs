using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	string _firstScene = "Camera";
	InputManager _inputManager;

	void Start() {
		_inputManager = gameObject.GetComponent<InputManager>();

		//Load first scene.
		SceneManager.LoadSceneAsync(_firstScene, LoadSceneMode.Additive);
	}

	void Update() {
		if (_inputManager.GetAction()) {
			SceneManager.UnloadSceneAsync(_firstScene);
			SceneManager.LoadSceneAsync("Walk", LoadSceneMode.Additive);
		}
	}
}
