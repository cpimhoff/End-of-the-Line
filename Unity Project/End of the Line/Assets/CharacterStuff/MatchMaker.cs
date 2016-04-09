using UnityEngine;
using System.Collections;

public class MatchMaker : MonoBehaviour {

	public CharacterPool characterPool;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Pair<CharacterStruct, CharacterStruct> getPair() {
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
