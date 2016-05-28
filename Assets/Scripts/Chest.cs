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

    Vector3 Destination = new Vector3();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (LocksLeft <= 0)
        {
            GameState.ChangeState(GameState.States.Endstate);
            if (!DoneWaiting)
            {
                if(Delay(2))
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
            if (Delay(0.01f))
            {
                transform.position = Vector3.Lerp(transform.position, Destination, .05f);
                //transform.localScale *= 1.005f;
            }
                

        }
        //if(!Delay(1))
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
