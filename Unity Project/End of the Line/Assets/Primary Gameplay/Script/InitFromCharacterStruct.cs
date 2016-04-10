using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// Given a CharacterStruct, this Component will modify other components to match the info from the CharacterStruct
/// </summary>
public class InitFromCharacterStruct : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
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

		var path = characterInfo.type + "/" + characterInfo.sprite;
		spriteRenderer.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;

		Vector3 scale = new Vector3( 1, 1, 1f );
		spriteRenderer.transform.localScale = scale;
	}

	public CharacterStruct GetCharacterInfo () {
		return this.characterInfo;
	}

}
