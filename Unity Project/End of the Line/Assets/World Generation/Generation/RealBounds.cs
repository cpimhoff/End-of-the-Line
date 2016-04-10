using UnityEngine;
using System.Collections;

public class RealBounds : MonoBehaviour {

	private Collider frame;

	void Start () {
		this.frame = this.GetComponent<Collider> ();
	}

	public bool Contains (Vector3 point)
	{
		Vector3    center;
		Vector3    direction;
		Ray        ray;
		RaycastHit hitInfo;
		bool       hit;

		var bounds  = frame.bounds;

		// Use collider bounds to get the center of the collider. May be inaccurate
		// for some colliders (i.e. MeshCollider with a 'plane' mesh)
		center = bounds.center;

		// Cast a ray from point to center
		direction = center - point;
		ray = new Ray(point, direction);
		hit = frame.Raycast(ray, out hitInfo, direction.magnitude);

		// If we hit the collider, point is outside. So we return !hit
		return !hit;
	}
}
