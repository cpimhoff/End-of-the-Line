using UnityEngine;
using System.Collections;

public class BloodSplatter : MonoBehaviour {

	public GameObject bloodEffect;

	public void Splat() {
		var location = this.transform.position;
		GameObject splat = GameObject.Instantiate (bloodEffect);
		splat.transform.position = this.transform.position;
		splat.transform.rotation = this.transform.rotation;
		splat.GetComponent<ParticleSystem> ().Play ();
	}
}
