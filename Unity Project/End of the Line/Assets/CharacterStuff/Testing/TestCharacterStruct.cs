using UnityEngine;
using System.Collections;

public class TestCharacterStruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var structy = CharacterStruct.createFromJSON ("{\"type\": \"stalkernet\", \"name\": \"Josh Aarons\", \"sprite\": \"aaronsj.png\"}");
		Debug.Log (structy.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
