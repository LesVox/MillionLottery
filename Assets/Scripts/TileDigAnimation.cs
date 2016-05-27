using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileDigAnimation : MonoBehaviour {

	private Image maskImage;
	private RectTransform rect;
	private RectTransform parentRect;
	private RectTransform bgndRect;
	public GameObject dugBGND;
	[SerializeField]
	private float showSpeed = 2f;
	private GameObject bgnd;

	// Use this for initialization
	void Awake () {
		maskImage = GetComponent<Image> ();
		rect = GetComponent<RectTransform> ();
		parentRect = transform.parent.GetComponent<RectTransform> ();
		rect.anchoredPosition3D = new Vector2(0,0);
		rect.sizeDelta = parentRect.sizeDelta;

		bgnd = (GameObject)Instantiate (dugBGND, Vector3.zero, Quaternion.identity);
		Invoke("ChangeParent", 0.01f);
	}

	void ChangeParent(){
		Vector3 startpos = bgnd.transform.position;
		bgnd.transform.SetParent (gameObject.transform, false);
		bgnd.transform.position = startpos;
	}

	public void DigBlock(){
		if (Player.instance != null) {
			SetDirection (Player.instance.Facing);
			StartCoroutine(ShowTile ());
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
		case 3:
			maskImage.fillMethod = Image.FillMethod.Vertical;
			maskImage.fillOrigin = (int)Image.OriginVertical.Bottom;
			break;
		// East
		case 4:
			maskImage.fillMethod = Image.FillMethod.Horizontal;
			maskImage.fillOrigin = (int)Image.OriginHorizontal.Left;
			break;
		// South
		case 1:
			maskImage.fillMethod = Image.FillMethod.Vertical;
			maskImage.fillOrigin = (int)Image.OriginVertical.Top;
			break;
		// West
		case 2:
			maskImage.fillMethod = Image.FillMethod.Horizontal;
			maskImage.fillOrigin = (int)Image.OriginHorizontal.Right;
			break;
		// StartDown
		case 0:
			maskImage.fillMethod = Image.FillMethod.Vertical;
			maskImage.fillOrigin = (int)Image.OriginVertical.Top;
			break;
		}


	}


}
