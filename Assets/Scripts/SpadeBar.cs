using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpadeBar : MonoBehaviour {
	
	void Update ()
    {
        GetComponent<Slider>().value = Player.instance.Steps;
	}
}
