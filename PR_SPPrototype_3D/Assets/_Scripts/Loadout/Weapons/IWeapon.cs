using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour {

	public float fireCooldown = 1;
	protected float timeRemaining = 0;

	public int maxAmmoClip = 100;
	protected int ammoRemaining;

	public float range = 10;

	public float baseDamagePerBullet = 1;

	public abstract bool FireWeapon(Vector3 position, Vector3 lookingAt);

	public abstract void Reload();

	public int GetRemainingAmmo() {
		return ammoRemaining;
	}

	private void Update() {
		timeRemaining -= Time.deltaTime;
	}

}
