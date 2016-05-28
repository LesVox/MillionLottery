using UnityEngine;
using System.Collections;

public class GameState {

	public enum States {Startstate, Playstate, Endstate, Paused, LoseState};

	public static States currentState = States.Startstate;

    public static bool ItemIsMoving = false;

	public static void ChangeState(States toState){
		if (currentState == toState)
			return;
		
		currentState = toState;
	}

}
