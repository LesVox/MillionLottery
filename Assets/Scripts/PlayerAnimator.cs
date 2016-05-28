using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Animator>().SetBool("IsMoving", Player.instance.IsMoving);
        GetComponent<Animator>().SetInteger("Facing", Player.instance.Facing);
    }
}
