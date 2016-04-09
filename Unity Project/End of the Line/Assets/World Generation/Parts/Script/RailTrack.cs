using UnityEngine;
using System.Collections;

public class RailTrack : MonoBehaviour {

	public RayGizmo curveToward;

	void OnTriggerEnter(Collider other) {
		var trainMover = other.GetComponent<TrainMovement> ();
		if (trainMover != null && this.enabled) {
			trainMover.target = curveToward.destination.position;
		}
	}

}
