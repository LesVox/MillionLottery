using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public bool Discovered = false;
    public bool Clickable = false;
    public Vector2 Position;
    public int Size;


    public void MovePlayer()
    {
        Player.instance.Move(transform.position, this);
    }

    void Update()
    {
        if (true)
        {

        }
    }

    bool PlayerBesideMe()
    {
        return true;
    }
}
