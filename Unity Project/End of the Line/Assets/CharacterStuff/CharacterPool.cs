using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CharacterPool : MonoBehaviour {

	public List<string> jsonFileLocationStrings;

	private List<CharacterStruct> characters;

	// Use this for initialization
	void Start () {
		characters = new List<CharacterStruct> ();

		foreach (string location in jsonFileLocationStrings) {
			var jsonContents = File.ReadAllText (location);

			var lines = File.ReadAllLines(location);

			// These JSON files are poorly formatted. Each line is a separate JSON object.
			// it's a hackathon though so we're cutting corners, you know?!
			foreach (var line in lines) {
				CharacterStruct character = CharacterStruct.createFromJSONString(line);
				characters.Add (character);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
