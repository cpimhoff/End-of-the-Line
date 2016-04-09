using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the generation, replacement, and transition between world Patches
/// </summary>
public class PatchManager : MonoBehaviour {

	public PatchGenerator generator;	// the generator to use for creating patches
	public GameObject trackedObject;	// the object which will trigger patch generation by moving close to off grid.

	private GameObject currentPatch;	// the current patch

	// Use this for initialization
	void Start () {
		this.currentPatch = generator.NextPatch ();

		this.currentPatch.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (patchRealBounds().Contains (trackedObject.transform.position)) {
			// the tracked object is within the patch's region	
		} else {
			// generate the template (populated)
			GameObject newPatch = generator.NextPatch ();

			// rotate the new patch to match the yaw of the tracked object
			newPatch.transform.rotation = this.trackedObject.transform.rotation;

			// move the tracked object to the start of the new patch
			var trainPoint = newPatch.GetComponent<PatchMeta> ().trainPlacementPoint.position;
			this.trackedObject.transform.position = trainPoint;

			// replace old patch
			newPatch.SetActive (true);
			Destroy(this.currentPatch.gameObject);
			this.currentPatch = newPatch;
		}
	}

	private RealBounds patchRealBounds () { // the bounding box of the current patch
		return this.currentPatch.GetComponent<RealBounds>();
	}
}
