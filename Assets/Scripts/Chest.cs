using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chest : MonoBehaviour {

    public static Chest instance;

    public List<GameObject> Locks;

    public int LocksLeft = 3;

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
        }
    }

    public void UnlockLock()
    {
        if (Locks.Count == 3 && LocksLeft > 0)
        {
            Locks[Locks.Count - LocksLeft].GetComponent<Animator>().Play("OpenLock");
            LocksLeft--;
        }
    }
}
