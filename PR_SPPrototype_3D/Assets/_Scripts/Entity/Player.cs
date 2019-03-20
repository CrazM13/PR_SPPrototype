using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : IEntity {

	private Vector3 prevMousePosition;

	// Start is called before the first frame update
	public override void Start() {

		prevMousePosition = Input.mousePosition;

		base.Start();
	}

	// Update is called once per frame
	public override void Update() {
		// Movement
		Vector3 movementVector = (Input.GetAxis("Horizontal") * transform.right) + (Input.GetAxis("Vertical") * transform.forward);

		float magnitude = movementVector.magnitude;
		movementVector = new Vector3(movementVector.x, 0, movementVector.z);
		movementVector.Normalize();

		movementVector *= magnitude;

		Rigidbody rb = GetComponent<Rigidbody>();
		if (magnitude > 0) rb.AddForce(movementVector * GetSpeed() * Time.deltaTime);
		else rb.velocity = Vector3.zero;

		// Turning
		float mouseMoveX = (Input.mousePosition - prevMousePosition).x;

		transform.Rotate(Vector3.up, mouseMoveX);

		prevMousePosition = Input.mousePosition;

		// Fireing
		if (Input.GetAxis("Fire") > 0) EntityManager.instance.SpawnCreeps();//FireWeapon();

		// Reload
		if (Input.GetAxis("Reload") > 0) ReloadWeapon();

		base.Update();
	}
}
