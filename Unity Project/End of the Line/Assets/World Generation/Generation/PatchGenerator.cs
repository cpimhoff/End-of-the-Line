﻿using UnityEngine;
using System.Collections.Generic;

public class PatchGenerator : MonoBehaviour {

	public MatchMaker matchMaker;
	public List<GameObject> templatePatches = new List<GameObject>();
	public GameObject characterTemplate;

	public List<GameObject> props;

	// Returns a new patch for the world (these start as inactive!)
	public GameObject NextPatch() {
		// get a random patch type
		int randIndex = Random.Range (0, templatePatches.Count);
		GameObject patch = GameObject.Instantiate (templatePatches [randIndex]);

		// replace objects tagged with ReplaceWithCharacter with characters
		GameObject[] replaceThese = GameObject.FindGameObjectsWithTag ("ReplaceWithCharacter");

		// Grab pairs (object_i, object_{i+1}), (object_{i+2}, object_{i+3}), etc
		//  and set replace with characters
		for (int i = 0; i < replaceThese.Length-1; 	i++) {
			var pair = matchMaker.getPair ();
			GameObject character1 = GameObject.Instantiate (characterTemplate);
			character1.GetComponent<InitFromCharacterStruct> ().SetCharacterInfo (pair.First);
			character1.transform.SetParent (patch.transform);
			character1.transform.position = replaceThese [i].transform.position;

			GameObject character2 = GameObject.Instantiate (characterTemplate);
			character2.GetComponent<InitFromCharacterStruct> ().SetCharacterInfo (pair.Second);
			character2.transform.SetParent (patch.transform);
			character2.transform.position = replaceThese [i+1].transform.position;

			replaceThese [i].tag = "Untagged";
			replaceThese [i].SetActive (false);
			replaceThese [i + 1].tag = "Untagged";
			replaceThese [i + 1].SetActive (false);

			// want i to go up by two, so increment it once here, and once more at the top of the loop :/
			i++;
		}

		// Grab Props
		GameObject[] replaceTheseProps = GameObject.FindGameObjectsWithTag("ReplaceWithProp");
		foreach (GameObject replaceMe in replaceTheseProps) {
			int randomIndex = Random.Range (0, props.Count);
			GameObject funProp = GameObject.Instantiate (props[randomIndex]);
			funProp.transform.SetParent (patch.transform);
			funProp.transform.position = replaceMe.transform.position;

			replaceMe.tag = "Untagged";
			replaceMe.SetActive (false);
			Destroy (replaceMe);
		}

		// return template (now properly constructed)
		patch.SetActive (false);
		return patch;
	}

}
