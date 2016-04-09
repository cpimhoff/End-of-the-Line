using UnityEngine;
using System.Collections;

/// <summary>
/// Moves a Train realistically up to a max speed.
/// </summary>
public class TrainMovement : MonoBehaviour {

	public float speed = 1.5f;
	public float maxVelocityMagnitude = 10;

	private Rigidbody body;

	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Rigidbody> ();
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		Vector3 force = new Vector3 (0, 0, speed);
		body.AddRelativeForce (force, ForceMode.Acceleration);

		if (body.velocity.sqrMagnitude >= (maxVelocityMagnitude*maxVelocityMagnitude)) {
			Vector3 normalled = body.velocity.normalized;
			Vector3 newVelocity = new Vector3 (body.velocity.x, body.velocity.y, body.velocity.z);
			newVelocity.x = normalled.x * maxVelocityMagnitude;
			newVelocity.y = normalled.y * maxVelocityMagnitude;
			newVelocity.z = normalled.z * maxVelocityMagnitude;
			body.velocity = newVelocity;
		}
	}
}
