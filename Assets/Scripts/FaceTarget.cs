using UnityEngine;
using System.Collections;

public class FaceTarget : MonoBehaviour {
	
	// Use this for initialization
	void OnEnable () {
		LookAtPlayer ();
	}

	void LookAtPlayer(){
		transform.LookAt (Player.instance.transform.position);
		transform.rotation = new Quaternion(0,0, transform.rotation.z, transform.rotation.w);
	}

}
