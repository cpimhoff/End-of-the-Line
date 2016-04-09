using UnityEngine;
using System.Collections;

public class RailFork : MonoBehaviour {

	public RayGizmo curveTowardLeft;
	public RayGizmo curveTowardRight;

	void OnTriggerEnter(Collider other) {
		var trainMover = other.GetComponent<TrainMovement> ();
		if (trainMover != null && this.enabled) {
			if (trainMover.GetLeverPosition () == TrainMovement.LeverPosition.Left) {
				trainMover.target = curveTowardLeft.destination.position;
			} else if (trainMover.GetLeverPosition () == TrainMovement.LeverPosition.Right) {
				trainMover.target = curveTowardRight.destination.position;
			}
		}
	}
}
