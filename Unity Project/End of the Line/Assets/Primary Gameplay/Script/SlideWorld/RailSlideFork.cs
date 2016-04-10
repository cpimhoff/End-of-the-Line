using UnityEngine;
using System.Collections;

public class RailSlideFork : MonoBehaviour {

	public RayGizmo turnTowardLeft;
	public RayGizmo turnTowardRight;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Train") && this.enabled) {
//			if (trainMover.GetLeverPosition () == TrainMovement.LeverPosition.Left) {
//				trainMover.target = curveTowardLeft.destination.position;
//			} else if (trainMover.GetLeverPosition () == TrainMovement.LeverPosition.Right) {
//				trainMover.target = curveTowardRight.destination.position;
//			}
		}
	}
}
