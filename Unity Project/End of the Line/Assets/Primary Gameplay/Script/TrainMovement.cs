using UnityEngine;
using System.Collections;

/// <summary>
/// Moves a Train realistically up to a max speed.
/// On Contacts with RailCurves and RailForks, turns the train to face the right way.
/// </summary>
public class TrainMovement : MonoBehaviour {

	public float speed = 1.5f;
	public float maxVelocityMagnitude = 10;
	public float rotationSpeed = 1.5f;

	public Vector3 target;

	// Use this for initialization
	void Start () {
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		var vectorToDestination = target - this.transform.position;
		vectorToDestination.Normalize ();

		this.transform.position = Vector3.MoveTowards (this.transform.position, target, (speed * Time.deltaTime));

		if (vectorToDestination != Vector3.zero) {
			transform.rotation = Quaternion.Slerp(
				transform.rotation,
				Quaternion.LookRotation(vectorToDestination),
				Time.deltaTime * rotationSpeed
			);
		}
	}

}
