using UnityEngine;
using System.Collections;

public class TestGeneratePatch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PatchGenerator gen = this.GetComponent<PatchGenerator> ();
		GameObject p = gen.NextPatch ();
		p.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
