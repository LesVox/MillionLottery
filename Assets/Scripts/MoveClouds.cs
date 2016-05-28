using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour
{

    public bool MoveLeft = false;

    private float MoveSpeed = 0.1f;

    private RectTransform trans;

    void Start()
    {
        trans = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 pos = trans.position;

        pos.x += (MoveLeft ? MoveSpeed : -MoveSpeed) * Time.deltaTime;

        if (pos.x < -3.7f)
        {
            pos.x = 3.7f;
        }
        else if (pos.x > 3.7f)
        {
            pos.x = -3.7f;
        }
    
        trans.position = pos;

    }

}
