using UnityEngine;
using System.Collections;

public class KillViaTrain : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		var other = col.rigidbody;
		Debug.Log (other.gameObject);
		if (other.gameObject.CompareTag("Character")) {
			other.GetComponent<DieWhenHitByTrain>().OnHitByTrain();
		}
	}
}
