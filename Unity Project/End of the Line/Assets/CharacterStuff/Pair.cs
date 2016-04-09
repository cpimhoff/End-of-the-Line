using UnityEngine;
using System.Collections;

public class Pair<T, U> {
	public Pair() {
	}

	public Pair(T first, U second) {
		this.First = first;
		this.Second = second;
	}

	public T First { get; set; }
	public U Second { get; set; }

	public Pair<T,U> Copy () {
		return new Pair<T, U> (this.First, this.Second);
	}

};
