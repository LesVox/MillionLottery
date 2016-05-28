using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour {

	public static PrizeManager instance;

	public Text winningText;

	[SerializeField]
	private int[] availablePrizes;

	void Awake(){
		if (instance == null) {
			instance = this;
		} 
	}

	public void GenerateWinnings(){
		int Winnings;

		if (availablePrizes.Length > 0) {

			Winnings = availablePrizes [Random.Range( 0, availablePrizes.Length)];

			if (winningText != null) {
				winningText.text = Winnings.ToString ();
				winningText.enabled = true;
			}


		} else {
			Debug.Log ("No Prizes specified.");
		}

	}


		
}
