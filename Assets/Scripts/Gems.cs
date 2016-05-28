using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gems : MonoBehaviour {

    public static Gems instance;

    public int NumberOfGems = 0;

    public Text NumberOfGemsText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddGems(int numberOfGemsToAdd)
    {
        NumberOfGems += numberOfGemsToAdd;
        NumberOfGemsText.text = NumberOfGems.ToString();
    }

    void Update()
    {

    }
}
