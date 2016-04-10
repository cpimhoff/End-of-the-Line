using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (Camera.main.transform.position, Vector3.up);
		this.transform.Rotate (0, 180, 0);	// for whatever reason, the above faces their backs to the camera
	}
}
