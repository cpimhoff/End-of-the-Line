using UnityEngine;
using System.Collections;
using System.Collections.Generic; //maybe?
using System.Web.Scripts

public class CharacterStruct {
	
	public string name;
	public string type; //student, animal, politician, etc.
	public string sprite; //takes in the person's png
	private Dictionary<string, string> data;

	void parseJSON(string jsonString) { //parses a JSON file and turns it into a type character struct
		var json = new JavaScriptSerializer();
		data = json.Deserialize<Dictionary<string, string>> (jsonString);
		data.TryGetValue ("name", out name); // tries to access the dictionary looking for the key name, then puts it in the variable name
		data.TryGetValue("type", out type); // tries to access the dictionary looking for the key name, then puts it in the variable name
		data.TryGetValue("sprite", out sprite); // tries to access the dictionary looking for the key name, then puts it in the variable name
	}
}