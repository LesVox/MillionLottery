using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour
{

    public bool MoveLeft = false;

    public int MoveSpeed = 50;

    private RectTransform trans;

    void Start()
    {
        trans = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 pos = trans.position;

        pos.x += (MoveLeft ? MoveSpeed : -MoveSpeed) * Time.deltaTime;

        if (pos.x < -60)
        {
            pos.x = 400;
        }
        else if (pos.x > 400)
        {
            pos.x = -60;
        }
    
        trans.position = pos;

    }

}
