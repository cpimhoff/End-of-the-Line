using UnityEngine;
using System.Collections;

public class ObserveChoices : MonoBehaviour {

	public CharacterPool characterPool;
	private Pair<CharacterStruct, CharacterStruct> runningObservation;

	void Start () {
		runningObservation = new Pair<CharacterStruct, CharacterStruct> ();
	}

	public void OnCharacterSurvived(CharacterStruct character) {
		runningObservation.First = character;
		if (IsObservationReady ()) {
			SendFavoringToCharacterPool ();
		}
	}

	public void OnCharacterKilled(CharacterStruct character) {
		runningObservation.Second = character;
		if (IsObservationReady ()) {
			SendFavoringToCharacterPool ();
		}
	}

	private void SendFavoringToCharacterPool () {
		var favoring = runningObservation.Copy ();

		characterPool.onFavorFirstOverSecond (favoring);

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
