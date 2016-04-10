using UnityEngine;
using System.Collections;

public class SlideWorldManager : MonoBehaviour {

	public PatchGenerator generator;

	public void GenerateNewPatchAtAnchor(Transform anchor) {
		GameObject patch = generator.NextPatch ();
		patch.transform.SetParent (this.transform);
		patch.transform.position = anchor.position;
		patch.transform.rotation = anchor.rotation;
		patch.SetActive (true);
	}

}
