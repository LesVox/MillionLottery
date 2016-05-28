using UnityEngine;
using System.Collections;

public class ParticleCanvas : MonoBehaviour {

	public static ParticleCanvas instance;

	// Use this for initialization
	void Awake() {
		if (instance == null)
			instance = this;
	}

}
