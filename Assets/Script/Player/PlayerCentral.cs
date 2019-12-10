using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe feita com o intuito de centralizar as referências das várias partes que compõem o Player.
// Ele também pode guardar flag úteis para diversas partes.
public class PlayerCentral : MonoBehaviour {
	PlayerHealth _playerHealth;
	PlayerMovement _playerMovement;

	[SerializeField] bool _hitStun = false;

	void Start() {
		_playerHealth = gameObject.GetComponent<PlayerHealth>();
		_playerMovement = gameObject.GetComponent<PlayerMovement>();
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
