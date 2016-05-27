using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    public static Chest instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
