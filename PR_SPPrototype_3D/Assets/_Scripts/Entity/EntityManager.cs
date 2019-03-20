using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {

	public static EntityManager instance;

	public Map map;

	public IEntity player;

	public ObjectPool[] laneCreeps;

	void Start() {
		if (!instance) instance = this;
		else Destroy(this);
	}

	void Update() {
		
	}

	public GameObject[] FindAll(EnumTeam team) {
		List<GameObject> enemies = new List<GameObject>();

		if (player.team == team) enemies.Add(player.gameObject);

		foreach (ObjectPool creepPool in laneCreeps) foreach (GameObject creep in creepPool.ToArray()) if (creep.GetComponent<IEntity>().team == team) enemies.Add(creep);

		return enemies.ToArray();
	}

	public IEntity FindTarget(EnumTeam enemyTeam, Vector3 position, Vector3 lookingAt) {
		IEntity target = null;

		foreach(GameObject enemy in FindAll(enemyTeam)) {
			Vector3 targetDir = enemy.transform.position - position;
			float angle = (Vector3.Angle(targetDir, lookingAt));

			if (angle >= -45 && angle <= 45) {
				if (target == null) target = enemy.GetComponent<IEntity>();
				else if (Vector3.Distance(position, target.transform.position) > Vector3.Distance(position, enemy.transform.position)) target = enemy.GetComponent<IEntity>();
			}
		}

		return target;
	}

	public void SpawnCreeps() {
		int lane = 0;
		bool good = false;
		foreach (ObjectPool creepPool in laneCreeps) {
			GameObject newCreep = creepPool.CreateObject();

			Vector3[] lanePoints = map.GetLanePoints(lane);

			IEntity newCreepEntity = newCreep.GetComponent<IEntity>();
			newCreepEntity.team = good ? EnumTeam.GOOD_GUYS : EnumTeam.BAD_GUYS;
			((AIBase) newCreepEntity).TargetPoint = lanePoints[!good ? 0 : lanePoints.Length - 1];

			newCreep.transform.position = lanePoints[good ? 0 : lanePoints.Length - 1];
			if (good) {
				good = false;
				lane++;
			} else {
				good = true;
			}
		}
	}

}
