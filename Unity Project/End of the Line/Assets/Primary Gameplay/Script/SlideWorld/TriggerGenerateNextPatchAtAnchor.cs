﻿using UnityEngine;
using System.Collections;

public class TriggerGenerateNextPatchAtAnchor : MonoBehaviour {

	public Transform anchor;
	private SlideWorldManager worldManager;

	void Start () {
		worldManager = GameObject.FindGameObjectWithTag ("SlideWorldManager").GetComponent<SlideWorldManager> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Train")) {
			worldManager.GenerateNewPatchAtAnchor (this.anchor);
		}
	}

}
