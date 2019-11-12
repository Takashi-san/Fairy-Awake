using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
	int _playerHP = 0;
	int _beliefPoints = 0;
	bool[] _itens = new bool[] { false, false, false };

	public int GetPlayerHP() {
		return _playerHP;
	}

	public void SetPlayerHP(int hp) {
		_playerHP = hp;
		return;
	}

	public int GetBeliefPoints() {
		return _beliefPoints;
	}

	public void SetBeliefPoints(int belief) {
		_beliefPoints = belief;
		return;
	}

	public void SetItem(int item) {
		_itens[item] = true;
	}

	public void ResetItem(int item) {
		_itens[item] = false;
	}

	public bool GetItem(int item) {
		return _itens[item];
	}
}
