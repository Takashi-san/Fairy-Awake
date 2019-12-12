using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe feita com o intuito de centralizar as referências das várias partes que compõem o Player.
// Ele também pode guardar flag úteis para diversas partes.
public class PlayerCentral : MonoBehaviour {
	PlayerHealth _playerHealth;
	PlayerMovement _playerMovement;
	InputManager _inputManager;

	[SerializeField] bool _hitStun = false;
	[SerializeField] GameObject _jItem;
	[SerializeField] GameObject _kItem;
	[SerializeField] GameObject _lItem;

	void Start() {
		_playerHealth = gameObject.GetComponent<PlayerHealth>();
		_playerMovement = gameObject.GetComponent<PlayerMovement>();
		_inputManager = FindObjectOfType<InputManager>().GetComponent<InputManager>();
	}

	void Update() {
		if (_inputManager.GetJ()) {
			_jItem.SetActive(true);
			_kItem.SetActive(false);
			_lItem.SetActive(false);
		}
		if (_inputManager.GetK()) {
			_kItem.SetActive(true);
			_jItem.SetActive(false);
			_lItem.SetActive(false);
		}
		if (_inputManager.GetL()) {
			_lItem.SetActive(true);
			_kItem.SetActive(false);
			_jItem.SetActive(false);
		}
	}

	public PlayerHealth GetHealth() {
		return _playerHealth;
	}

	public PlayerMovement GetMovement() {
		return _playerMovement;
	}

	public void SetHitStun(bool hitStun) {
		_hitStun = hitStun;
	}

	public bool GetHitStun() {
		return _hitStun;
	}
}
