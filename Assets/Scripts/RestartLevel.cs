using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public static RestartLevel instance;

    public GameObject Child;

    private static bool CanPressScreenToRestart = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	public void Restart(){
		//Application.LoadLevel (Application.loadedLevel);
        GameState.ChangeState(GameState.States.Startstate);
	    GameState.ItemIsMoving = false;
	    CanPressScreenToRestart = false;
        SceneManager.LoadScene(0);
	}

    public void SetPressScreenToRestart()
    {
        instance.StartCoroutine(ChillUntillBill());
    }

    IEnumerator ChillUntillBill()
    {
        yield return new WaitForSeconds(1.5f);
        CanPressScreenToRestart = true;
        Child.GetComponent<Image>().enabled = true;
        yield return null;
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
