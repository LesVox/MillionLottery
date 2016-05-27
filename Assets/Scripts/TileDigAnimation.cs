using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileDigAnimation : MonoBehaviour {

	private Image image;
	[SerializeField]
	private float showSpeed = 2f;

	// Use this for initialization
	void Awake () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			SetDirection (1);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			SetDirection (2);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			SetDirection (3);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			SetDirection (4);
			StopAllCoroutines ();
			StartCoroutine (ShowTile ());
		}
	}

	IEnumerator ShowTile(){
		float rate = 1f / showSpeed;
		float currentTime = 0;

		while (currentTime < 1) {

			currentTime += rate * Time.deltaTime;

			image.fillAmount = Mathf.Lerp (0f, 1f, currentTime);

			yield return null;
		}
	}

	void SetDirection(int direction){
		switch (direction) {
		// North
		case 1:
			image.fillMethod = Image.FillMethod.Vertical;
			image.fillOrigin = (int)Image.OriginVertical.Bottom;
			break;
		// South
		case 2:
			image.fillMethod = Image.FillMethod.Vertical;
			image.fillOrigin = (int)Image.OriginVertical.Top;
			break;
		// West
		case 3:
			image.fillMethod = Image.FillMethod.Horizontal;
			image.fillOrigin = (int)Image.OriginHorizontal.Right;
			break;
		// East
		case 4:
			image.fillMethod = Image.FillMethod.Horizontal;
			image.fillOrigin = (int)Image.OriginHorizontal.Left;
			break;
		}
	}


}
