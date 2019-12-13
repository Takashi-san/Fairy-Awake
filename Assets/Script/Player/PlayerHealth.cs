using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour {
	[SerializeField] int _hp = 100;
	[SerializeField] int _maxHp = 100;
	[SerializeField] GameObject _textUI;
	StageManager _stageManager;
	PlayerCentral _playerCentral;
	TextMeshProUGUI _textUIHealth;

	void Start() {
		_stageManager = FindObjectOfType<StageManager>().GetComponent<StageManager>();
		_playerCentral = gameObject.GetComponent<PlayerCentral>();
		if (_textUI) {
			_textUIHealth = _textUI.GetComponent<TextMeshProUGUI>();
		}
	}

	void Update() {
		if (_textUIHealth) {
			_textUIHealth.text = "HP: " + _hp;
		}
	}

	public int GetHealth() {
		return _hp;
	}

	public void Damage(int damage) {
		if (!_playerCentral.GetHitStun()) {
			_hp -= damage;
			_playerCentral.SetHitStun(true);
		}

		if (_hp <= 0) {
			InstaKill();
		}
	}

	public void InstaKill() {
		_hp = 0;
		Death();
	}

	public void Heal(int heal) {
		_hp += heal;

		if (_hp > _maxHp) {
			FullHeal();
		}
	}

	public void FullHeal() {
		_hp = _maxHp;
	}

	void Death() {
		StartCoroutine(WaitALittle());
	}

	IEnumerator WaitALittle() {
		/*
		Debug.Log("GameOver in 3...");
		yield return new WaitForSeconds(1);
		Debug.Log("GameOver in 2...");
		yield return new WaitForSeconds(1);
		Debug.Log("GameOver in 1...");
		yield return new WaitForSeconds(1);
		*/
		Debug.Log("GameOver!");
		_stageManager.ChangeScene("GameOverScreen");
		yield break;
	}
}
