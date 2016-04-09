using UnityEngine;
using System.Collections;

public class MatchMaker : MonoBehaviour {

	public CharacterPool characterPool;
	private int numberOfPairsGiven = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// any of the CharacterStruts can be null (to put nobody on that track)
	public Pair<CharacterStruct, CharacterStruct> getPair() {
		var pool = characterPool.getCharacterPool ();

		// Grab two randos!
		Random rand = new Random ();
		int firstIndex = rand.Next(pool.Count);
		int secondIndex = rand.Next (pool.Count);

		CharacterStruct person1 = pool [firstIndex];
		CharacterStruct person2 = pool[secondIndex];

		// For the first few pairs, let one part of the track be empty
		//	(so the decision isn't too hard, ya know?)
		if (numberOfPairsGiven < 5) {
			// 50% chance of left or right side being empty.
			if (rand.NextDouble () > 0.5) {
				return new Pair<CharacterStruct, CharacterStruct> (null, person2);
			} else {
				return new Pair<CharacterStruct, CharacterStruct> (person1, null);
			}
		} else {
			return new Pair<CharacterStruct, CharacterStruct> (person1, person2);
		}
	}

}
