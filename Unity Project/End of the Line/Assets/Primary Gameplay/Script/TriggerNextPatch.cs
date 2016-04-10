﻿using UnityEngine;
using System.Collections;

public class TriggerNextPatch : MonoBehaviour {

	public Transform atAnchor;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Train") && this.enabled) {
			Debug.Log ("Generating another Patch");
			PatchManager manager = PatchManager.FindAManager ();
			if (manager != null) {
				manager.GeneratePatchAtAnchor (this.atAnchor);
				this.enabled = false;
			}
		}
	}

}
