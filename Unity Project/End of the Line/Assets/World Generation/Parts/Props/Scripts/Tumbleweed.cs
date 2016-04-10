using UnityEngine;
using System.Collections;

public class Tumbleweed : MonoBehaviour {

	public float spinRate = 1f;
	public float moveRate = 1f;
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(0,(spinRate * Time.deltaTime),0));
		this.transform.Translate (new Vector3 ((moveRate * Time.deltaTime),0,0));
	}
}
