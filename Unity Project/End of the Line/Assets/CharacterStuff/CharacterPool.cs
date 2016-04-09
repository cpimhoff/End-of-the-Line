using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CharacterPool : MonoBehaviour {

	public List<string> jsonFileLocationStrings;

	private List<CharacterStruct> characters;

	public Dictionary<CharacterStruct, int> deathMap; // for cutie

	// Use this for initialization
	void Start () {
		this.deathMap = new Dictionary<CharacterStruct, int> ();
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<CharacterStruct> getCharacterPool() {
		return characters;
	}

	public void addDeathForCharacter(CharacterStruct character) {
		if (this.deathMap.ContainsKey (character)) {
			this.deathMap [character]++;
		} else {
			this.deathMap.Add (character, 1);
		}
	}
}
