using UnityEngine;
using System.Collections.Generic;

public class PatchGenerator : MonoBehaviour {

	public GameObject testCharacter;
	public List<GameObject> templatePatches = new List<GameObject>();

	// Returns a new patch for the world (these start as inactive!)
	public GameObject NextPatch() {
		// get a random patch type
		int randIndex = Random.Range (0, templatePatches.Count);
		GameObject patch = GameObject.Instantiate (templatePatches [randIndex]);

		// replace objects tagged with ReplaceWithCharacter with characters
		GameObject[] replaceThese = GameObject.FindGameObjectsWithTag("ReplaceWithCharacter");
		foreach (GameObject replaceMe in replaceThese) {
			//new character at the location of 'replaceMe'
			GameObject character = GameObject.Instantiate (testCharacter);
			character.transform.SetParent (patch.transform);
			character.transform.position = replaceMe.transform.position;

			replaceMe.tag = "Untagged";
			replaceMe.SetActive (false);
		}

		// return template (now properly constructed)
		patch.SetActive (false);
		return patch;
	}

}
