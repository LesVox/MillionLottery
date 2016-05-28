using UnityEngine;
using System.Collections;

public class MoveItem : MonoBehaviour
{
        
    public float moveSpeed = 2;

    public bool isKey;

    public Vector3 TargetPosition;

    public bool ItemFound = false;

    private bool StartedMoving = false;

    // Use this for initialization
    void Start ()
    {
        TargetPosition = isKey ? Chest.instance.GetComponent<RectTransform>().position : Gems.instance.GetComponent<RectTransform>().position;
    }

    void Update()
    {
        if (!Player.instance.IsMoving && !StartedMoving && ItemFound)
        {
            StartedMoving = true;
            transform.SetParent(Front.instance.transform, false);
            StartCoroutine(StartMove());
		}
    }

    IEnumerator StartMove()
    {
        float rate = 1f / moveSpeed;
        float currentTime = 0;

//        Vector3 startPos = GetComponent<RectTransform>().position;
		Vector3 startPos = Player.instance.transform.position;

		Vector3 center = (startPos + TargetPosition) / 2;
		// Center offset
		center -= new Vector3(+150, 0 ,0);

		Vector3 startRelCenter = startPos - center;
		Vector3 targetRelCenter = TargetPosition - center;

        while (currentTime < 1)
        {

            currentTime += rate * Time.deltaTime;

//            GetComponent<RectTransform>().position = Vector3.Lerp(startPos, TargetPosition, currentTime);
			GetComponent<RectTransform>().position = Vector3.Slerp(startRelCenter, targetRelCenter, currentTime);
			GetComponent<RectTransform> ().position += center;
            //Debug.Log(currentTime);
            
            yield return null;
        }

        if (isKey)
        {
            Chest.instance.UnlockLock();
        }

        Destroy(gameObject);
    }
}
