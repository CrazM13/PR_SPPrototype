using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBase : IEntity {

	NavMeshAgent nav;

	public Vector3 TargetPoint { get { return nav.destination; } set { MoveTo(value); } }

	private IEntity attackTarget = null;

	// Start is called before the first frame update
	public void Awake() {

		nav = GetComponent<NavMeshAgent>();

		base.Start();
	}

	// Update is called once per frame
	public override void Update() {

		if (attackTarget) {
			if (Vector3.Distance(attackTarget.transform.position, transform.position) < loadout.GetWeaponRange()) {
				TargetPoint = transform.position;

				transform.LookAt(attackTarget.transform);
				FireWeapon();
			} else {
				TargetPoint = attackTarget.transform.position;
			}
		} else {
			IEntity newTarget = EntityManager.instance.FindTarget(team == EnumTeam.GOOD_GUYS ? EnumTeam.BAD_GUYS : EnumTeam.GOOD_GUYS, transform.position, transform.forward);
			if (newTarget) {
				attackTarget = newTarget;
			}
		}

		base.Update();
	}

	public void Warp(Vector3 target) {
		nav.Warp(target);
	}

	public void MoveTo(Vector3 target) {
		nav.SetDestination(target);
	}

	public void AttackTarget(IEntity target) {
		TargetPoint = target.transform.position;
	}
}
