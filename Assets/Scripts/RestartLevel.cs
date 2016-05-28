using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    private static bool CanPressScreenToRestart = false;

	public void Restart(){
		//Application.LoadLevel (Application.loadedLevel);
        GameState.ChangeState(GameState.States.Startstate);
	    GameState.ItemIsMoving = false;
	    CanPressScreenToRestart = false;
        SceneManager.LoadScene(0);
	}

    public static void SetPressScreenToRestart()
    {
        CanPressScreenToRestart = true;
    }

    void Update()
    {
        if (CanPressScreenToRestart)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Restart();
            }
        }
    }
}
