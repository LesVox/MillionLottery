using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shovels : MonoBehaviour {

    public static Shovels instance;

    public int NumberOfShovels = 0;

    public Text NumberOfShovelsText;
	public Image shovelImage;

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
    }

	void CheckNumberOfShovels(){
		for(int i = 0; i < Player.instance.Steps; i++){
				
		}
	}
}
