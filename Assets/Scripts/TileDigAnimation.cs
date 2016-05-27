using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileDigAnimation : MonoBehaviour {

	private Image maskImage;
	private RectTransform rect;
	private RectTransform parentRect;
	public GameObject dugBGND;
	[SerializeField]
	private float showSpeed = 2f;

	// Use this for initialization
	void Awake () {
		maskImage = GetComponent<Image> ();
		rect = GetComponent<RectTransform> ();
		parentRect = transform.parent.GetComponent<RectTransform> ();
		rect.position = parentRect.position;
		rect.sizeDelta = parentRect.sizeDelta;
		GameObject bgnd = (GameObject)Instantiate (dugBGND, Vector3.zero, Quaternion.identity);
		Vector3 startpos = bgnd.transform.position;
		bgnd.transform.SetParent (gameObject.transform, false);
		bgnd.transform.position = startpos;
	}
	
	// Update is called once per frame
	void Update () {
//		/*
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			SetDirection (1);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			SetDirection (3);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			SetDirection (4);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			SetDirection (2);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
//		*/
	}

	public void DigBlock(){
		if (Player.instance != null) {
			SetDirection (Player.instance.Facing);
			ShowTile ();
		} else {
			Debug.Log ("No player found.");
		}
	}

	IEnumerator ShowTile(){
		float rate = 1f / showSpeed;
		float currentTime = 0;

		while (currentTime < 1) {

			currentTime += rate * Time.deltaTime;

			maskImage.fillAmount = Mathf.Lerp (0f, 1f, currentTime);

			yield return null;
		}
	}

	void SetDirection(int direction){
		switch (direction) {
		// North
		case 1:
			maskImage.fillMethod = Image.FillMethod.Vertical;
			maskImage.fillOrigin = (int)Image.OriginVertical.Bottom;
			break;
		// East
		case 2:
			maskImage.fillMethod = Image.FillMethod.Horizontal;
			maskImage.fillOrigin = (int)Image.OriginHorizontal.Left;
			break;
		// South
		case 3:
			maskImage.fillMethod = Image.FillMethod.Vertical;
			maskImage.fillOrigin = (int)Image.OriginVertical.Top;
			break;
		// West
		case 4:
			maskImage.fillMethod = Image.FillMethod.Horizontal;
			maskImage.fillOrigin = (int)Image.OriginHorizontal.Right;
			break;
		
		}
	}


}
