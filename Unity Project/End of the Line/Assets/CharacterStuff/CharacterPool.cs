using UnityEngine;
using System.Collections.Generic;

public class CharacterPool : MonoBehaviour {

	public List<string> jsonFileLocationStrings;

	private List<CharacterStruct> characters;

	// Use this for initialization
	void Start () {
		characters = new List<CharacterStruct> ();

		foreach (string location in jsonFileLocationStrings) {
			var filestream = new System.IO.FileStream(location,
				System.IO.FileMode.Open,
				System.IO.FileAccess.Read,
				System.IO.FileShare.ReadWrite);
			var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

			CharacterStruct character = CharacterStruct.createFromJSON(file.ReadToEnd ());

			characters.Add (character);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
