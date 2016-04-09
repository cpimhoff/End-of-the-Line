using UnityEngine;
using System.Collections;

public class PatchGenerator : MonoBehaviour {

	public List<GameObject> templatePatches = new List<GameObject>();

	// Returns a new patch for the world
	GameObject NextPatch() {

		// get a random patch type
		int randIndex = Random.Range (0, templatePatches.Count);
		GameObject template = GameObject.Instantiate (templatePatches [randIndex]);

		// replace objects tagged with ReplaceWithCharacter with characters


		// return template (now properly constructed)
		return template;
	}

}
