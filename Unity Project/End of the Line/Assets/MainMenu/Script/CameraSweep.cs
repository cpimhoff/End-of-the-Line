using UnityEngine;
using System.Collections;

public class CameraSweep : MonoBehaviour {

	public Vector3 end;
	private Quaternion endingRotation;
	public float duration = 5.0f;
	private float progress = 0f;

	// Use this for initialization
	void Start () {
		endingRotation = Quaternion.Euler (end);
		this.enabled = false;
	}

	void Update () {
		if (progress > duration) {
			this.enabled = false;
		}

		progress += Time.deltaTime;
		var alpha = Mathf.Min ((progress / duration), 1f);
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endingRotation, alpha);
	}

}
