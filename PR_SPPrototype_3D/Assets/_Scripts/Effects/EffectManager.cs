using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager {

	List<Effect> activeEffects;

	public EffectManager() {
		activeEffects = new List<Effect>();
	}

	public void Update() {
		foreach (Effect eff in activeEffects) eff.Update();
	}

	public void AddEffect(Effect newEffect) {
		activeEffects.Add(newEffect);
	}

	public float GetArmourValue(float armour) {
		float retArmour = armour;

		foreach (Effect eff in activeEffects) retArmour = eff.GetArmourValue(retArmour);

		return retArmour;
	}

	public int GetMaxHealth(int maxHealth) {
		int retMaxHealth = maxHealth;

		foreach (Effect eff in activeEffects) retMaxHealth = eff.GetMaxHealth(retMaxHealth);

		return retMaxHealth;
	}

	public int GetHealth(int health) {
		int retHealth = health;

		foreach (Effect eff in activeEffects) retHealth = eff.GetHealth(retHealth);

		return retHealth;
	}

	public float GetMovementSpeed(float movementSpeed) {
		float retMoveSpeed = movementSpeed;

		foreach (Effect eff in activeEffects) retMoveSpeed = eff.GetArmourValue(retMoveSpeed);

		return retMoveSpeed;
	}

	public float GetAttackSpeed(float attackSpeed) {
		float retAttSpeed = attackSpeed;

		foreach (Effect eff in activeEffects) retAttSpeed = eff.GetArmourValue(retAttSpeed);

		return retAttSpeed;
	}

	public float GetCritChance(float critChance) {
		float retCritChance = critChance;

		foreach (Effect eff in activeEffects) retCritChance = eff.GetArmourValue(retCritChance);

		return retCritChance;
	}

}
