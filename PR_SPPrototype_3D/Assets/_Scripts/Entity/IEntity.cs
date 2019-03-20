using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEntity : MonoBehaviour {

	[Header("Team")]
	public EnumTeam team;

	[Header("Stats")]
	[Range(0, 1)]
	public float armour;
	public int maxHealth;
	public int health;
	public float baseSpeed = 1000;
	public float movementSpeed = 1;
	[Range(0, 1)]
	public float attackSpeed = 1;
	[Range(0, 1)]
	public float critChance = 0;

	[Header("Loadout")]
	public LoadoutObject loadout;
	public EffectManager effects;

	#region Stats
	public float GetArmourValue() {
		float retArmour = armour;

		// Check Loadout
		retArmour += effects.GetArmourValue(retArmour);

		return retArmour;
	}

	public int GetMaxHealth() {
		int retMaxHealth = maxHealth;

		// Check Loadout
		retMaxHealth += effects.GetMaxHealth(retMaxHealth);

		return retMaxHealth;
	}

	public int GetHealth() {
		int retHealth = health;

		// Check Loadout
		retHealth += effects.GetHealth(retHealth);

		return retHealth;
	}

	public float GetHealthPercentage() {
		return (float) GetHealth() / GetMaxHealth();
	}

	public float GetMovementSpeed() {
		float retMoveSpeed = movementSpeed;

		// Check Loadout
		retMoveSpeed += effects.GetMovementSpeed(retMoveSpeed);

		return retMoveSpeed;
	}

	public float GetAttackSpeed() {
		float retAttSpeed = attackSpeed;

		// Check Loadout
		retAttSpeed += effects.GetAttackSpeed(retAttSpeed);

		return retAttSpeed;
	}

	public float GetCritChance() {
		float retCritChance = critChance;

		// Check Loadout
		retCritChance += effects.GetCritChance(retCritChance);

		return retCritChance;
	}

	public float GetSpeed() {
		return baseSpeed * GetMovementSpeed();
	}
	#endregion

	#region Basic Entity Delegation
	public void FireWeapon() {

		Vector3 lookingAt = transform.forward;

		loadout.FireWeapon(transform.position, lookingAt);
	}

	public void ReloadWeapon() {
		loadout.ReloadWeapon();
	}

	public void TriggerAbility(int slot) {
		//loadout.TriggerAbility(slot);
	}
	#endregion

	#region Unity Events
	public virtual void Start() {
		effects = new EffectManager();
	}

	public virtual void Update() {
		effects.Update();

		if (GetHealth() <= 0) gameObject.SetActive(false);

	}
	#endregion

	#region Damage
	public int Damage(float baseDamage, float critical, float distance, float range, Vector2 hitPoint, float piercing) {
		int retDamage = (int)(((baseDamage - Mathf.Max(0, GetArmourValue() - piercing)) * (critical)) / ((distance / range) + 1));

		health -= retDamage;
		Debug.Log(health);

		return retDamage;
	}
	#endregion

}
