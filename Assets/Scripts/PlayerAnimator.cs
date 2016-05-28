using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Animator>().SetBool("IsMoving", Player.instance.IsMoving);
        GetComponent<Animator>().SetInteger("Facing", Player.instance.Facing);
        GetComponent<Animator>().SetBool("FacingRight", Player.instance.FacingRight);

        if (Player.instance.Facing == 4)
        {
            Player.instance.FacingRight = true;
        }
        else if(Player.instance.Facing == 2)
        {
            Player.instance.FacingRight = false;
        }
    }
}
