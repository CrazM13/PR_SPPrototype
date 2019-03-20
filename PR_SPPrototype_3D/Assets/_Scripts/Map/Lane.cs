using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	public Transform[] lanePoints;

	public Vector3[] GetLanePoints() {

		Vector3[] points = new Vector3[lanePoints.Length];

		for (int i = 0; i < lanePoints.Length; i++) {
			points[i] = lanePoints[i].position;
		}

		return points;

	}

}
