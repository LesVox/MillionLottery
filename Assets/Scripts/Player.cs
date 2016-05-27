using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player instance;

    public int Steps = 6;

    //100 för att spelarens första drag ska bara vara lagligt genom if-satsen i Check-Adjacents första villkor
    public int PlayerTileI = 100;
    public int PlayerTileJ = 100;
    public int Facing;

    public float moveSpeed = 2;

    public bool IsMoving = false;
    public bool Starting = true; 
        

    // Use this for initialization
    void Awake ()
    {
	    if (instance == null)
        {
            instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator MovePlayer(Vector3 TargetPosition)
    {
        IsMoving = true;
        float rate = 1f / moveSpeed;
        float currentTime = 0;

        Vector3 startPos = transform.position;

        while (currentTime < 1) {
            
            currentTime += rate * Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, TargetPosition, currentTime);

            yield return null;
        }
        
        IsMoving = false;
    }

    public void Move(Vector3 TargetPosition, Block TargetTile)
    {
        if (!IsMoving)
        {
            if (Steps > 0)
            {
                if (!TargetTile.Discovered)
                {
                    Steps--;
                    Steps = Mathf.Max(Steps, 0);
                }
                StopAllCoroutines();
                StartCoroutine(MovePlayer(TargetPosition));
                

                if(PlayerTileI - TargetTile.ValueI == 0 && PlayerTileJ - TargetTile.ValueJ != 0)
                {
                    if(PlayerTileJ > TargetTile.ValueJ)
                    {
                        //Going up
                        Facing = 1;
                    }
                    else
                    {
                        //Going down
                        Facing = 3;
                    }
                }
                else
                {
                    if(PlayerTileI > TargetTile.ValueI)
                    {
                        //Going right
                        Facing = 2;
                    }
                    else
                    {
                        //Going left
                        Facing = 4;
                    }
                }

                PlayerTileI = TargetTile.ValueI;
                PlayerTileJ = TargetTile.ValueJ;


            }
        }
    }
}
