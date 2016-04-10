using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LabelUpdater : MonoBehaviour {

	public Text label;
	public float fadePercentagePerSecond = 20f;

	public void UpdateLabel (string newValue) {
		label.text = newValue;
		label.color = new Color (label.color.r, label.color.g, label.color.b, 1f);
	}

	void Update() {
		var newAlpha = Mathf.Max (0, label.color.a - (fadePercentagePerSecond * Time.deltaTime));
		label.color = new Color (label.color.r, label.color.g, label.color.b, newAlpha);
	}

}
