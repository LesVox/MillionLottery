using UnityEngine;
using System.Collections;

public class SetActiveObjects : MonoBehaviour {

	public GameObject targetObject;

	public void Activate(){
		if (targetObject != null)
			targetObject.SetActive (true);
	}

}
