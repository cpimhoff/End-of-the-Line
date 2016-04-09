using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (Camera.main.transform.position, Vector3.up);
	}
}
