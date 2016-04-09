using UnityEngine;
using System.Collections;

/// <summary>
/// Given a CharacterStruct, this Component will modify other components to match the info from the CharacterStruct
/// </summary>
public class InitFromCharacterStruct : MonoBehaviour {

	private CharacterStruct characterInfo;

	// Initialization
	void Start () {
		if (characterInfo == null) {
			Debug.LogError ("InitFromCharacterStruct.info not set before initialization of a GameObject");
		} else {
			SetCharacterInfo (characterInfo);
		}
	}

	// Updates the values of various attributes on this character to be equal to those defined by the provided CharacterStruct
	public void SetCharacterInfo (CharacterStruct newInfo) {
		this.characterInfo = newInfo;

//		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
//		renderer.sprite = characterInfo.sprite;
	}

	public CharacterStruct GetCharacterInfo () {
		return this.characterInfo;
	}

}
