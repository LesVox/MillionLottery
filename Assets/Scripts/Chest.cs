using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

    public static Chest instance;

    public List<GameObject> Locks;

    public int LocksLeft = 3;

    public float Timer = 0;
    public float TimerMax = 0;
    public bool DoneWaiting = false;

	public GameObject chestBehindParticles;

    Vector3 Destination = new Vector3();
	private bool movedToMiddle;
	private bool startedMoving;
	private Animator anim;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

		anim = GetComponent<Animator> ();
    }

    void Update()
    {
        if (LocksLeft <= 0)
        {
            GameState.ChangeState(GameState.States.Endstate);
            if (!DoneWaiting)
            {
                if(Delay(1))
                {
                    DoneWaiting = true;
                    foreach (var item in Locks)
                    {
                        Destroy(item);
                    }
                }
                
            }
        }

        if (DoneWaiting)
        {
			if (Delay(0.01f) && !startedMoving)
            {
//                transform.position = Vector3.Lerp(transform.position, Destination, .05f);
				StartCoroutine(MoveChest());	
				startedMoving = true;
                //transform.localScale *= 1.005f;
            }
                

        }
        //if(!Delay(1))
    }

	IEnumerator MoveChest(){
		float rate = 1f / 0.5f;
		float currentTime = 0f;

		Vector3 startPos = transform.position;
		float targetScaleRate = 1.005f;
		Vector3 targetScale = transform.localScale * targetScaleRate;
		Vector3 startScale = transform.localScale;


		while (currentTime < 1f) {
			anim.SetTrigger ("Bounce");
			currentTime += rate * Time.deltaTime;
			transform.position = Vector3.Lerp(startPos, Destination, currentTime);
			transform.localScale = Vector3.Lerp (startScale, targetScale, currentTime);
			yield return null;
		}

		movedToMiddle = true;

		if (chestBehindParticles != null)
			chestBehindParticles.SetActive (true);
		
	}

	public void ClickChest(){
		if (LocksLeft <= 0 && movedToMiddle) {
			OpenChest ();
		}
	}

	void OpenChest(){
		if (anim != null) {
			anim.SetTrigger ("Open");
			Invoke ("CreateWinnings", 1);
		}
			
	}

	void CreateWinnings(){
		PrizeManager.instance.GenerateWinnings ();

        RestartLevel.SetPressScreenToRestart();
    }

    public void UnlockLock()
    {
        if (Locks.Count == 3 && LocksLeft > 0)
        {
            Locks[Locks.Count - LocksLeft].GetComponent<Animator>().Play("OpenLock");
            LocksLeft--;
        }
    }

    public bool Delay(float WaitForSeconds)
    {
        TimerMax = WaitForSeconds;
        Timer += Time.deltaTime;
        if (Timer > TimerMax)
        {
            Timer = 0;
            return true;
        }
        return false;
    }
}
