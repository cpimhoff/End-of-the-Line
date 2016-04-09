using UnityEngine;
using System.Collections.Generic;

public class MatchMaker : MonoBehaviour {

	public CharacterPool characterPool;
	private int numberOfPairsGiven = 16;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	// @Nullable: any of the CharacterStruts can be null (to put nobody on that track)
	public Pair<CharacterStruct, CharacterStruct> getPair() {
		List<CharacterStruct> pool = characterPool.getCharacterPool ();

		// Grab two randos!
		int firstIndex = Random.Range(0, pool.Count);
		int secondIndex = Random.Range (0, pool.Count);

		CharacterStruct person1 = pool [firstIndex];
		CharacterStruct person2 = pool[secondIndex];

		// For the first few pairs, let one part of the track be empty
		//	(so the decision isn't too hard, ya know?)
		if (numberOfPairsGiven < 15) {
			// 50% chance of left or right side being empty on the first few.
			if (Random.Range((float)0, (float)1) > 0.5) {
				this.numberOfPairsGiven++;
				return new Pair<CharacterStruct, CharacterStruct> (null, person2);
			} else {
				this.numberOfPairsGiven++;
				return new Pair<CharacterStruct, CharacterStruct> (person1, null);
			}
		} else {
			this.numberOfPairsGiven++;
			return new Pair<CharacterStruct, CharacterStruct> (person1, person2);
		}
	}

}
