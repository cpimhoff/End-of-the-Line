using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the generation, replacement, and transition between world Patches
/// </summary>
public class PatchManager : MonoBehaviour {

	public PatchGenerator generator;	// the generator to use for creating patches

	public void GeneratePatchAtAnchor(Transform anchor) {
		GameObject patch = generator.NextPatch ();
		patch.transform.SetParent (this.transform);
		patch.transform.position = anchor.position;
		patch.transform.rotation = anchor.rotation;
		patch.SetActive (true);
	}

	public static PatchManager FindAManager() {
		GameObject possible = GameObject.FindGameObjectWithTag ("WorldGenerator");
		if (possible != null) {
			return possible.GetComponent<PatchManager> ();
		} else {
			return null;
		}
	}

}
