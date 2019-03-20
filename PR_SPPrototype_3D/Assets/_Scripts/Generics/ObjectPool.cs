using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public GameObject objectPrefab;

	public int copiesToHave = 60;

	public Queue<GameObject> gameObjects;

	void Start() {

		gameObjects = new Queue<GameObject>();

		for (int i = 0; i < copiesToHave; i++) {
			GameObject newGameObject = Instantiate(objectPrefab);

			newGameObject.SetActive(false);

			gameObjects.Enqueue(newGameObject);
		}
	}

	public GameObject[] ToArray() {
		return gameObjects.ToArray();
	}

	public GameObject CreateObject() {

		GameObject newObj = gameObjects.Dequeue();

		newObj.SetActive(true);

		gameObjects.Enqueue(newObj);

		return newObj;
	}
}
