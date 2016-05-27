using UnityEngine;
using System.Collections;

public class Front : MonoBehaviour
{
    public static Front instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
