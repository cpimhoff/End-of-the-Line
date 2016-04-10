using UnityEngine;
using System.Collections;

/// <summary>
/// Assign this to a Character, and it will die when it is hit by a train.
/// </summary>
public class DieWhenHitByTrain : MonoBehaviour {

	RequireComponent Collider;

	private ObserveChoices theObserver;

	void Start () {
		theObserver = GameObject.FindGameObjectWithTag ("TheObserver").GetComponent<ObserveChoices> ();
	}

	// Called when a Collider enters this object's trigger space
	public void OnTriggerEnter(Collider other) {
		Debug.Log ("Somebody got hi by a "+other.tag+" "+other.name);

		if (other.CompareTag ("Train")) {
			Debug.Log ("HEY Somebody got hi by a train");
			OnHitByTrain ();
		}
	}

 	public void OnHitByTrain () {
		// to-done! blood
		GetComponent<BloodSplatter>().Splat ();

		// send death to observer
		InitFromCharacterStruct info = this.GetComponent<InitFromCharacterStruct>();
		theObserver.OnCharacterKilled (info.GetCharacterInfo ());
		this.gameObject.tag = "Untagged";

		GameObject survivor = GameObject.FindGameObjectWithTag ("Character");
		if (survivor != null) {
			InitFromCharacterStruct survivorInfo = survivor.GetComponent<InitFromCharacterStruct>();
			theObserver.OnCharacterSurvived (survivorInfo.GetCharacterInfo ());
		}

		// TODO: repent

		Destroy (this.gameObject);
	}
}
