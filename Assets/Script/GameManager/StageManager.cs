﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	[SerializeField] string _firstScene;
	InputManager _inputManager;

	void Start() {
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();

		//Load first scene.
		StartCoroutine(LoadScene(_firstScene));
	}

	void Update() {
		if (_inputManager.GetAction()) {
			ChangeScene("Walk");
		}
	}

	IEnumerator LoadScene(string sceneName) {
		AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		yield return loading;
		Scene loadedScene = SceneManager.GetSceneByName(sceneName);
		SceneManager.SetActiveScene(loadedScene);
		yield break;
	}

	IEnumerator LoadScene(int sceneBuildIndex) {
		AsyncOperation loading = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);
		yield return loading;
		Scene loadedScene = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
		SceneManager.SetActiveScene(loadedScene);
		yield break;
	}

	IEnumerator UnloadActiveScene() {
		Scene activeScene = SceneManager.GetActiveScene();
		AsyncOperation unloading = SceneManager.UnloadSceneAsync(activeScene);
		yield return unloading;
		yield break;
	}

	public void ChangeScene(string sceneName) {
		StartCoroutine(UnloadActiveScene());
		StartCoroutine(LoadScene(sceneName));
	}

	public void ChangeScene(int sceneBuildIndex) {
		StartCoroutine(UnloadActiveScene());
		StartCoroutine(LoadScene(sceneBuildIndex));
	}
}
