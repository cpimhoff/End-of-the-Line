using UnityEngine;
using System.Collections;

public class RailTrack : MonoBehaviour {

	public RayGizmo curveToward;

	void OnTriggerEnter(Collider other) {
		var trainMover = other.GetComponent<TrainMovement> ();
		if (trainMover != null && this.enabled) {
			var destination = curveToward.destination.position;
			destination.y = trainMover.transform.position.y;
			trainMover.target = destination;
		}
	}

}
