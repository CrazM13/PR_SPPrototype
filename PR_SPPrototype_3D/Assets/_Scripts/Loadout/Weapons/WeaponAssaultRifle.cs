using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAssaultRifle : IWeapon {

	public override bool FireWeapon(Vector3 position, Vector3 lookingAt) {
		if (ammoRemaining > 0 && timeRemaining <= 0) {
			ammoRemaining--;
			timeRemaining = fireCooldown;

			Debug.Log(position + " :: " + lookingAt);

			Debug.DrawRay(position, lookingAt.normalized * range, Color.red, 10);
			if (Physics.Raycast(position, lookingAt, out RaycastHit hit)) {
				Debug.Log(hit.transform.name);
				IEntity entity = hit.transform.GetComponent<IEntity>();
				if (entity) {
					entity.Damage(baseDamagePerBullet, 1, hit.distance, range, hit.point, 0);
				}
			}

			Debug.Log("FIRE -- Remaining: " + ammoRemaining);

			return true;
		} else {
			return false;
		}
	}

	public override void Reload() {
		ammoRemaining = maxAmmoClip;
	}

}
