using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] int _hp = 100;
	[SerializeField] int _maxHp = 100;

	public int GetHealth() {
		return _hp;
	}

	public void Damage(int damage) {
		//if (!_playerCentral.GetHitStun()) {
		_hp -= damage;
		//	_playerCentral.SetHitStun(true);
		//}

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
		Destroy(gameObject);
	}
}
