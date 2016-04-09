using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CharacterPool : MonoBehaviour {

	public List<string> jsonFileLocationStrings;

	private List<CharacterStruct> characters;
	private List<CharacterStruct> rankedPool;

	// Use this for initialization
	void Start () {
		this.name = "the pool!";
		this.characters = new List<CharacterStruct> ();

		foreach (string location in jsonFileLocationStrings) {
			string[] lines = File.ReadAllLines(location);

			// These JSON files are poorly formatted. Each line is a separate JSON object.
			// it's a hackathon though so we're cutting corners, you know?!
			foreach (string line in lines) {
				CharacterStruct character = CharacterStruct.createFromJSONString(line);
				this.characters.Add (character);
			}
		}
		// Keep a copy for ranking!
		characters.CopyTo(this.rankedPool);
	}

	
	public void onFavorFirstOverSecond(Pair<CharacterStruct, CharacterStruct> choicePair) {
		CharacterStruct first = choicePair.First;
		CharacterStruct second = choicePair.Second;

		int indexFirst = this.rankedPool.IndexOf (first);
		int indexSecond = this.rankedPool.IndexOf (second);

		if (indexFirst > indecSecond) {
			// If First is later in the list than Second, 

			// remove it (temporarily)
			this.rankedPool.RemoveAt(indexFirst);

			// and then reinsert it closer to the front!
			this.rankedPool.Insert(indexSecond, First);
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
