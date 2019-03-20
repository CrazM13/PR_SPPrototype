using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect {

	private Dictionary<string, float> effects;

	private float maxDuration;
	private float timeLeft;

	public void AddEffect(string effect, float value) {
		effects.Add(effect, value);
	}

	public float GetArmourValue(float armour) {
		float retArmour = armour;

		retArmour += effects["ARMOUR"];

		return retArmour;
	}

	public int GetMaxHealth(int maxHealth) {
		int retMaxHealth = maxHealth;

		retMaxHealth += (int)effects["MAX_HEALTH"];

		return retMaxHealth;
	}

	public int GetHealth(int health) {
		int retHealth = health;

		retHealth += (int)effects["HEALTH"];

		return retHealth;
	}

	public float GetMovementSpeed(float movementSpeed) {
		float retMoveSpeed = movementSpeed;

		retMoveSpeed += effects["MOVEMENT_SPEED"];

		return retMoveSpeed;
	}

	public float GetAttackSpeed(float attackSpeed) {
		float retAttSpeed = attackSpeed;

		retAttSpeed += effects["ATTACK_SPEED"];

		return retAttSpeed;
	}

	public float GetCritChance(float critChance) {
		float retCritChance = critChance;

		retCritChance += effects["CRIT_CHANCE"];

		return retCritChance;
	}

	public void SetDuration(float duration) {
		timeLeft = maxDuration = duration;
	}

	public void Update() {
		timeLeft -= Time.deltaTime;
	}
}
