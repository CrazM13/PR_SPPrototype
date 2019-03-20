using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutObject : MonoBehaviour {

	public IWeapon weapon;
	
	//public int abilitySlots;
	//public IAbility[] abilities;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void FireWeapon(Vector3 position, Vector3 lookingAt) {
		weapon.FireWeapon(position, lookingAt);
	}

	public void ReloadWeapon() {
		weapon.Reload();
	}

	public float GetWeaponRange() {
		return weapon.range;
	}

	public int GetAmmoRemaining() {
		return weapon.GetRemainingAmmo();
	}
}
