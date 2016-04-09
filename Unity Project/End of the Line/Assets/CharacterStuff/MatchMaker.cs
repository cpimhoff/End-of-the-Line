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
		characterPool.getCharacterPool ();

		// return a nice and random pair! Or a totally deterministic one amiright
		CharacterStruct friend = new CharacterStruct();
		friend.name = "Charlie Imhoff";
		friend.sprite = "fakePic.lol";
		friend.type = "stalkernet";

		CharacterStruct enemy = new CharacterStruct();
		enemy.name = "Prof. Quirrel";
		enemy.sprite = "troll in the dungeon.lol";
		enemy.type = "stalkernet";

		return new Pair<CharacterStruct, CharacterStruct>(friend, enemy);
	}

}
