using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shovels : MonoBehaviour {

    public static Shovels instance;

    public int NumberOfShovels = 0;

    public Text NumberOfShovelsText;
	public Image shovelImage;

	[SerializeField]
	private GameObject shovelDestroyParticle;
	[SerializeField]
	private GameObject[] shovels;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    void Update()
    {
        if (NumberOfShovelsText != null)
        {
            NumberOfShovels = Player.instance.Steps;
            NumberOfShovelsText.text = NumberOfShovels.ToString();
        }

		CheckNumberOfShovels ();
    }

	void CheckNumberOfShovels(){
		for(int i = 0; i < shovels.Length; i++){
			if (i < Player.instance.Steps) {
				shovels [i].SetActive (true);
			} else {

				if (shovels [i].activeInHierarchy && shovelDestroyParticle != null) {
					shovelDestroyParticle.transform.position = shovels [i].transform.position - new Vector3(0.5f,0.5f,0);
					shovelDestroyParticle.SetActive (false);
					shovelDestroyParticle.SetActive (true);
				}
				shovels [i].SetActive (false);
			}
		}
	}
}
