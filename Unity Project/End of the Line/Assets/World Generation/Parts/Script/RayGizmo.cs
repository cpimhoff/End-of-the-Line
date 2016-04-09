using UnityEngine;
using System.Collections;

public class RayGizmo : MonoBehaviour {

	public Transform origin;
	public Transform destination;

	public Vector3 direction {
		get {
			return destination.position - origin.position;
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Ray ray = new Ray(origin.position, direction);
		Gizmos.DrawRay (ray);
	}
}
