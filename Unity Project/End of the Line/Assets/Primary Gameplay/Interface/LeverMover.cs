using UnityEngine;
using System.Collections;

public class LeverMover : MonoBehaviour {

	public enum LeverPosition {Left, Right};
	public LeverPosition position;

	public void OnToggle () {
		var rectTransform = this.GetComponent<RectTransform> ();

		if (position == LeverPosition.Left) {
			rectTransform.Rotate (0, 0, -90);
			position = LeverPosition.Right;
		} else if (position == LeverPosition.Right) {
			rectTransform.Rotate (0, 0, 90);
			position = LeverPosition.Left;
		}
	}

}
