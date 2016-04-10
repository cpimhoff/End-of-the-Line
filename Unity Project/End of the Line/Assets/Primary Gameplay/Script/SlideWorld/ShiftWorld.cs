using UnityEngine;
using System.Collections;

public class ShiftWorld : MonoBehaviour {

	public float speed = 5f;
	public float acceleration = 0.05f;
	public float maxSpeed = 10f;

	public float rotationSpeed = 1.5f;
	
	// Update is called once per frame
	void Update () {
		var currentY = this.transform.position.y;	// this will constrain the Y axis

		// prepare to slide along Z
		var newZ = this.transform.position.z - (speed * Time.deltaTime);
		var nextPosition = new Vector3 (this.transform.position.x, this.transform.position.y, newZ);
//		var changeVector = (nextPosition - this.transform.position).normalized;

		// slide!
		this.transform.position = nextPosition;

		// accelerate
		speed = Mathf.Min(maxSpeed, speed + (acceleration * Time.fixedDeltaTime));

		// lock the Y axis to whatever it was when we started
		this.transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
	}
}
