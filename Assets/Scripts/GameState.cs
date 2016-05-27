using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public enum States {Startstate, Playstate, Endstate};
	public static States currentState = States.Startstate;

	public static GameState instance;


	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
