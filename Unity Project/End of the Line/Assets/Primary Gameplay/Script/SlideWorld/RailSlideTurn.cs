using UnityEngine;
using System.Collections;

public class RailSlideTurn : MonoBehaviour {

	public float rotateBy;
	private SlideWorldManager worldManager;

	void Start () {
		var world = GameObject.FindGameObjectWithTag ("SlideWorldManager");
		if (world != null) {
			worldManager = world.GetComponent<SlideWorldManager> ();
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Train") && this.enabled) {
//			Vector3 worldRotation = worldManager.transform.rotation.eulerAngles;
//			Vector3 difference = turnToward.destination.position - turnToward.origin.position;
//			float radianAngleOfRay =  Mathf.PI/2f - Mathf.Atan2 (difference.z, difference.x);
//			Debug.Log (radianAngleOfRay);
//			float radianDifferenceOfContainer = radianAngleOfRay - worldRotation.y;
//			Debug.Log (radianDifferenceOfContainer);

			worldManager.transform.RotateAround (this.transform.position, Vector3.up, rotateBy);
			this.enabled = false;
		}
	}

}
