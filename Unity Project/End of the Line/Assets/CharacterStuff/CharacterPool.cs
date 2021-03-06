﻿using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class CharacterPool : MonoBehaviour {

	private List<CharacterStruct> characters;
	private List<CharacterStruct> rankedPool;

	// Use this for initialization
	void Start () {
		this.name = "the pool!";
		this.characters = new List<CharacterStruct> ();
		this.rankedPool = new List<CharacterStruct> ();

		var jsonFileLocationStrings = new string [] { "devs", "celebrities", "animals" };

		foreach (string location in jsonFileLocationStrings) {
			var document = Resources.Load<TextAsset> (location);
			if (document == null) {
				continue;
			}
			string[] lines = Regex.Split (document.text, "\n|\r|\r\n");

			// These JSON files are poorly formatted. Each line is a separate JSON object.
			// it's a hackathon though so we're cutting corners, you know?!
			foreach (string line in lines) {
				if (!(line.Length > 3)) {
					continue;
				}

				CharacterStruct character = CharacterStruct.createFromJSONString(line);
				this.characters.Add (character);

				// we'll keep track of ranks in this list. populate it here!
				this.rankedPool.Add (character);
			}
		}
	}

	
	public void onFavorFirstOverSecond(Pair<CharacterStruct, CharacterStruct> choicePair) {
		CharacterStruct first = choicePair.First;
		CharacterStruct second = choicePair.Second;

		int indexFirst = this.rankedPool.IndexOf (first);
		int indexSecond = this.rankedPool.IndexOf (second);

		if (indexFirst > indexSecond) {
			// If First is later in the list than Second, 

			// remove it (temporarily)
			this.rankedPool.RemoveAt(indexFirst);

			// and then reinsert it closer to the front!
			this.rankedPool.Insert(indexSecond, first);
		}

		// Remove Y from viable candidates, since Y is dead now
		this.characters.Remove(second);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<CharacterStruct> getCharacterPool() {
		return characters;
	}

	public List<CharacterStruct> getRankedPool() {
		return this.rankedPool;
	}
}
