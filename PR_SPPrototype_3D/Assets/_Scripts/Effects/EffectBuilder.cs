using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBuilder {

	private Effect effect;

	public EffectBuilder() {
		effect = new Effect();
	}

	public EffectBuilder AddArmour(float percentage) {
		effect.AddEffect("ARMOUR", percentage);

		return this;
	}

	public EffectBuilder AddMaxHealth(float additionalHealth) {
		effect.AddEffect("MAX_HEALTH", additionalHealth);

		return this;
	}

	public EffectBuilder AddHealth(float additionalHealth) {
		effect.AddEffect("HEALTH", additionalHealth);

		return this;
	}

	public EffectBuilder AddMovementSpeed(float percentage) {
		effect.AddEffect("MOVEMENT_SPEED", percentage);

		return this;
	}

	public EffectBuilder AddAttackSpeed(float percentage) {
		effect.AddEffect("ATTACK_SPEED", percentage);

		return this;
	}

	public EffectBuilder AddCritChance(float percentage) {
		effect.AddEffect("CRIT_CHANCE", percentage);

		return this;
	}

	public EffectBuilder AddCustomValue(string effectName, float value) {
		effect.AddEffect(effectName, value);

		return this;
	}

	public EffectBuilder SetDuration(float duration) {
		effect.SetDuration(duration);

		return this;
	}

	public Effect Build() {
		return effect;
	}

}
