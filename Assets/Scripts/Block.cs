using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public bool Discovered = false;
    public bool Clickable = false;
    public Vector2 Position;
    public int Size;
    public int ValueI;
    public int ValueJ;
    public bool IsAdjacent = false;

    public void MovePlayer()
    {
        CheckAdjacent();

        if (IsAdjacent)
        {
            Player.instance.Move(transform.position, this);
            Discovered = true;
        }
            
    }

    public void CheckAdjacent()
    {
        if (Player.instance.Starting || Mathf.Abs(Player.instance.PlayerTileI - ValueI) == 1 && Mathf.Abs(Player.instance.PlayerTileJ - ValueJ) == 0 || Mathf.Abs(Player.instance.PlayerTileJ - ValueJ) == 1 && Mathf.Abs(Player.instance.PlayerTileI - ValueI) == 0)
        {
            IsAdjacent = true;
            Player.instance.Starting = false;
        }
        else
        {
            IsAdjacent = false;
        }
    }

}
