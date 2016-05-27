using UnityEngine;
using System.Collections;

public class Gems : MonoBehaviour {

    public static Gems instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
