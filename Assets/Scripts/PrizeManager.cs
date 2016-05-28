using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour {

	public static PrizeManager instance;

	public GameObject winScreen;
	public Text winningText;

	[SerializeField]
	private int[] availablePrizes;
	[SerializeField]
	private GameObject[] prizeImages;

	void Awake(){
		if (instance == null) {
			instance = this;
		} 
	}

	public void GenerateWinnings(){
		int Winnings;
		int winnumber;

		if (availablePrizes.Length > 0 && prizeImages.Length > 0) {

			winnumber = Random.Range (0, availablePrizes.Length);

			Winnings = availablePrizes [winnumber];
			prizeImages [winnumber].SetActive (true);
			winScreen.SetActive (true);
			// Old wintext
//			if (winningText != null && winScreen != null) {
//				winningText.text = Winnings.ToString () + " Kr";
//				
//			}


		} else {
			Debug.Log ("No Prizes or images specified.");
		}

	}


		
}
