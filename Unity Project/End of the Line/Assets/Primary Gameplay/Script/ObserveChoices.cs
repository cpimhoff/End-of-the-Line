using UnityEngine;
using System.Collections;

public class ObserveChoices : MonoBehaviour {

	public CharacterPool characterPool;
	private Pair<CharacterStruct, CharacterStruct> runningObservation;

	void Start () {
		runningObservation = new Pair<CharacterStruct, CharacterStruct> ();
	}

	public void OnCharacterSurvived(CharacterStruct character) {
		Debug.Log ("Survive Obervation Recieved");
		runningObservation.First = character;
		if (IsObservationReady ()) {
			SendFavoringToCharacterPool ();
		}
	}

	public void OnCharacterKilled(CharacterStruct character) {
		Debug.Log ("Kill Obervation Recieved");
		runningObservation.Second = character;
		if (IsObservationReady ()) {
			SendFavoringToCharacterPool ();
		}
	}

	private void SendFavoringToCharacterPool () {
		Debug.Log ("Full Obervation Recieved, sending...");
		var favoring = runningObservation.Copy ();

		// characterPool.onFavorFirstOverSecond (favoring);

		runningObservation = new Pair<CharacterStruct, CharacterStruct> ();
	}

	private bool IsObservationReady() {
		if ((runningObservation.First != null) && (runningObservation.Second != null)) {
			return true;
		} else {
			return false;
		}
	}

}
