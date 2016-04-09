using UnityEngine;
using System.Collections;

/// <summary>
/// Assign this to a Character, and it will die when it is hit by a train.
/// </summary>
public class DieWhenHitByTrain : MonoBehaviour {

	public string trainTag = "Train";
	RequireComponent Collider;

	// Called when a Collider enters this object's trigger space
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag (trainTag)) {
			OnHitByTrain ();
		}
	}

 	private void OnHitByTrain () {
		Destroy (this.gameObject);

		// to-done! blood
		GetComponent<BloodSplatter>().Splat ();



		// TODO: send death info to CharacterPool
		// TODO: repent
	}
}
