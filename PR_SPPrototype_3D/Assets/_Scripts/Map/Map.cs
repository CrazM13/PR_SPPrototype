using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public Lane[] lanes;

	public Vector3[] GetLanePoints(int lane) {
		return lanes[lane].GetLanePoints();
	}

}
