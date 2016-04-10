using UnityEngine;
using System.Collections;

/// <summary>
/// Moves a Train realistically up to a max speed.
/// On Contacts with RailCurves and RailForks, turns the train to face the right way.
/// </summary>
public class TrainMovement : MonoBehaviour {

	public enum LeverPosition {Left, Right};
	public LeverPosition leverPosition = LeverPosition.Left;

	public float speed = 5f;
	public float acceleration = 0.05f;
	public float maxSpeed = 10f;

	public float rotationSpeed = 1.5f;

	public Vector3 target;

	// Use this for initialization
	void Start () {
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		var currentY = this.transform.position.y;	// this will constrain the Y axis

		// get direction vector
		var vectorToDestination = target - this.transform.position;
		vectorToDestination.y = 0;
		vectorToDestination.Normalize ();

		// move toward vector
		this.transform.position = Vector3.MoveTowards (this.transform.position, target, (speed * Time.deltaTime));

		// if we're moving in a directly, rotate to face that direction
		if (vectorToDestination != Vector3.zero) {
			transform.rotation = Quaternion.Slerp(
				transform.rotation,
				Quaternion.LookRotation(vectorToDestination),
				Time.deltaTime * rotationSpeed
			);
		}

		// accelerate
		speed = Mathf.Min(maxSpeed, speed + (acceleration * Time.fixedDeltaTime));

		// lock the Y axis to whatever it was when we started
		this.transform.position = new Vector3 (transform.position.x, currentY, transform.position.z);
	}

	public void ToggleLeverPosition () {
		if (leverPosition == LeverPosition.Left) {
			leverPosition = LeverPosition.Right;
		} else if (leverPosition == LeverPosition.Right) {
			leverPosition = LeverPosition.Left;
		}
	}

	public LeverPosition GetLeverPosition () {
		return leverPosition;
	}

}