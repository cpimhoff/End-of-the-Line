using UnityEngine;
using System.Collections.Generic;

public class MatchMaker : MonoBehaviour {

	public CharacterPool characterPool;
	private int numberOfPairsGiven = 0;

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
		CharacterStruct person1 = pool [firstIndex];

//		// remove this person so we don't get dupe choices
		pool.Remove (person1);

		CharacterStruct person2 = null;
		if (pool.Count > 0) {
			int secondIndex = Random.Range (0, pool.Count);
			person2 = pool [secondIndex];
		} // if there's no one left in the list, then it will stay null

//		// okay now add that person back in... this feels icky but hey it's a hackathon!!!!111!11
		pool.Add(person1);

		// For the first few pairs, let one part of the track be empty
		//	(so the decision isn't too hard, ya know?)
		if (numberOfPairsGiven < 1) {
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
