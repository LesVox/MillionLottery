using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	public void Restart(){
		//Application.LoadLevel (Application.loadedLevel);
        GameState.ChangeState(GameState.States.Startstate);
	    GameState.ItemIsMoving = false;
        SceneManager.LoadScene(0);
	}
}
