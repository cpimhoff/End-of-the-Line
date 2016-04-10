using UnityEngine;
using System.Collections;
using System.Collections.Generic; //maybe?
using SimpleJSON;

public class CharacterStruct {
	
	public string name;
	public string type; //student, animal, politician, etc.
	public string sprite; //takes in the person's png
	private Dictionary<string, string> data;

	public static CharacterStruct createFromJSONString(string jsonString) { //parses a JSON file and turns it into a type character struct
		JSONNode jsonParsed = JSON.Parse(jsonString);

		string theName = jsonParsed ["name"];
		string theType = jsonParsed ["type"];
		string theSprite = jsonParsed ["sprite"];

		if (theName != null && theType != null && theSprite != null) {
			var charStr = new CharacterStruct ();
			charStr.name = theName;
			charStr.type = theType;
			charStr.sprite = theSprite;

			return charStr;
		} else {
			Debug.LogError ("trouble parsing JSON");

			return null;
		}
	}

	public string toString() {
		return this.name;
	}
}