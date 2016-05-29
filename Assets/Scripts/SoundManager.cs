using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	[SerializeField]
	private AudioSource musicLoopSound;
	[SerializeField]
	private AudioSource birdsChirpSound;
	[SerializeField]
	private AudioSource digSound;
	[SerializeField]
	private AudioSource gemPickupSound;
	[SerializeField]
	private AudioSource gemDropOffSound;
	[SerializeField]
	private AudioSource keyDropOffSound;
	[SerializeField]
	private AudioSource loseStateSound;
	[SerializeField]
	private AudioSource winStateSound;
	[SerializeField]
	private AudioSource chestWiggleSound;
	[SerializeField]
	private AudioSource chestOpenSound;
	[SerializeField]
	private AudioSource chestCheer;
	[SerializeField]
	private AudioSource[] keyPickupSounds;

	int numberOfKeys;
	bool playedWinSound;
	bool playedLoseSound;
	float timeElapsed;
	float birdChirpDelay = 6f;

	// Use this for initialization
	void Awake () {

		if (instance == null) {
			instance = this;
		}

		PlaySound (musicLoopSound);
	}

	// Update is called once per frame
	void Update () {
		CheckDigSound ();
		CheckState ();
	}

	void CheckState(){
		// win
		if (GameState.currentState == GameState.States.Endstate && !playedWinSound) {
			SwitchSound (musicLoopSound,winStateSound);
			playedWinSound = true;
		} if (GameState.currentState == GameState.States.LoseState && !playedLoseSound) {
			SwitchSound (musicLoopSound, loseStateSound);
			playedLoseSound = true;
		} if (GameState.currentState == GameState.States.Startstate && !musicLoopSound.isPlaying) {
			PlaySound (musicLoopSound);
		}

		// BirdChirp
		if (timeElapsed + birdChirpDelay < Time.time && !birdsChirpSound.isPlaying) {
			birdsChirpSound.Play ();
			timeElapsed = Time.time;
		}
	}

	public void PlayChestOpenSound(){
		PlaySound (chestOpenSound);
		PlaySound (chestCheer);
	}

	void CheckDigSound(){
		if (Player.instance.IsDigging && Player.instance.IsMoving && !digSound.isPlaying) {
			PlaySound (digSound);
		} else if (!Player.instance.IsDigging && !Player.instance.IsMoving){
			StopSound (digSound);
		}
	}

	public void PlayGemPickup(){
		PlaySound (gemPickupSound);
	}

	public void PlayKeyPickup(){

		if (numberOfKeys == 0) {
			PlaySound (keyPickupSounds [0]);
		} else if (numberOfKeys == 1) {
			PlaySound (keyPickupSounds [1]);
		} else if (numberOfKeys == 2) {
			PlaySound (keyPickupSounds [2]);
		}

	}

	void PlaySound(AudioSource soundSource){
		if (soundSource != null)
			soundSource.Play ();
	}

	public void StopSound(AudioSource soundSource){
		if (soundSource != null)
			soundSource.Stop ();
	}

	public void SwitchSound(AudioSource turnOffSound, AudioSource turnOnSound){
		if (turnOffSound != null && turnOnSound) {
			turnOffSound.Stop ();
			turnOnSound.Play ();
		}
	}


}
