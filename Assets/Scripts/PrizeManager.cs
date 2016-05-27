using UnityEngine;
using System.Collections;

public class PrizeManager : MonoBehaviour {

	public static PrizeManager instance;

	public int startingTreasureAmount;
	public int startingKeyAmount;

	private int foundTreasure;
	private int foundKeys;

	void Awake(){
		if (instance == null) {
			instance = this;
		} 

		ResetNumbers ();
	}

	void ResetNumbers(){
		foundTreasure = 0;
		foundKeys = 0;
	}

	public int GetFoundTreasures(){
		return foundTreasure;
	}

	public int GetFoundKeys(){
		return foundKeys;
	}
		
}
