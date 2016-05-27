using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player instance;

    public float moveSpeed = 2;

    public bool IsMoving = false;

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
            Debug.Log(currentTime);
            yield return null;
        }
        
        IsMoving = false;
        
    }

    public void Move(Vector3 TargetPosition)
    {
        if (!IsMoving)
        {
            StopAllCoroutines();
            StartCoroutine(MovePlayer(TargetPosition));
            //transform.position = TargetPosition;
        }
    }
}
