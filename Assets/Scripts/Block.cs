using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Block : MonoBehaviour {

    public bool Discovered = false;
    public bool DiscoveredItem = false;
    public bool Clickable = false;
    public Vector2 Position;
    public int Size;
    public int ValueI;
    public int ValueJ;
    public bool IsFirstBlock = false;
    public bool IsAdjacent = false;
    public float Timer = 0;
    public float TimerMax = 0;
    public List<GameObject> ItemsToSpawn;
    public Transform ItemParent;

    public Image BlockImage;

    public enum Item
    {
        None, Key, Gem1, Gem2, Gem3
    }

    public Item ContainsItem = Item.None;

    public Image Arrow;
    public GameObject Showel;
    private RectTransform ArrowTransform;
	private TileDigAnimation tileDig;
	private GameObject itemObject;
	private int previousSteps;

    void Start()
    {
        ArrowTransform = Arrow.GetComponent<RectTransform>();
		tileDig = GetComponentInChildren<TileDigAnimation> ();
		previousSteps = Player.instance.Steps;
    }

    public void MovePlayer()
    {
        Player.instance.JustClicked = true;
        if (IsAdjacent && GameState.currentState != GameState.States.Endstate)
        {
			
			previousSteps = Player.instance.Steps;
            if (!Player.instance.Starting)
            {
                Player.instance.Move(transform.position, this);
                Player.instance.DoingFirstMove = false;
                Player.instance.JustClicked = false;
            }

            else
            {
                IsFirstBlock = true;
            }

            if (!Discovered && tileDig != null && previousSteps > 0) {
				tileDig.DigBlock ();
			}

			Discovered = true;

            if (Player.instance.Starting)
                Player.instance.Starting = false;
        }
            
    }

    public void CheckAdjacent()
    {
        if (Player.instance.DoingFirstMove && ValueJ == 4 || Mathf.Abs(Player.instance.PlayerTileI - ValueI) == 1 && Mathf.Abs(Player.instance.PlayerTileJ - ValueJ) == 0 || Mathf.Abs(Player.instance.PlayerTileJ - ValueJ) == 1 && Mathf.Abs(Player.instance.PlayerTileI - ValueI) == 0)
        {
            IsAdjacent = true;
        }
        else
        {
            IsAdjacent = false;
        }
    }

    public bool Delay(float WaitForSeconds)
    {
        TimerMax = WaitForSeconds;
        Timer += Time.deltaTime;
        if (Timer > TimerMax)
        {
            Timer = 0;
            return true;
        }
        return false;
    }

    void Update()
    {
        CheckAdjacent();
        if (IsAdjacent && !Player.instance.IsMoving && Player.instance.Steps > 0 && GameState.currentState != GameState.States.Endstate)
        {
            Arrow.enabled = true;
            if (!Discovered)
            {
                Showel.GetComponent<Image>().enabled = true;
            }
            RotateArrow();
        }
        else
        {
            Arrow.enabled = false;
            Showel.GetComponent<Image>().enabled = false;
        }

        if (IsFirstBlock)
        {
            if (Delay(1.15f))
            {
                IsFirstBlock = false;
                MovePlayer();
            }
        }

        if (PlayerOnthisBlock())
        {
            InstantiateItem(true);
        }
    }

    void InstantiateItem(bool ItemFound)
    {
        if (!DiscoveredItem && ContainsItem != Item.None)
        {
            DiscoveredItem = true;
            var item = (GameObject)Instantiate(ItemsToSpawn[(int)ContainsItem - 1]);
            item.transform.SetParent(ItemParent, false);
			item.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
            item.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
			Vector3 startPos = item.transform.position;

			itemObject = item;
			itemObject.transform.SetParent(ItemParent, false);
			Invoke ("DelayedSet", 0.01f);
            item.GetComponent<MoveItem>().ItemFound = ItemFound;
			item.transform.position = startPos;

            GameState.ItemIsMoving = true;
        }
    }

	void DelayedSet(){
		
	}

    public void ShowItem()
    {
        InstantiateItem(false);
        StartCoroutine(FadeBlock());
    }

    IEnumerator FadeBlock()
    {

        var image = BlockImage.GetComponent<Image>();
        var alpha = image.color.a;

        while (alpha > 0.4f)
        {

            alpha -= 2f * Time.deltaTime;

            image.color *= new Color(1, 1, 1, 0);
            image.color +=  new Color(0,0,0,alpha);

            yield return null;
        }
    }

    void RotateArrow()
    {
        if (ValueJ < Player.instance.PlayerTileJ)
        {
            ArrowTransform.rotation = Quaternion.Euler(0,0,0);
            Showel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,-30,0);
        }
        else if (ValueJ > Player.instance.PlayerTileJ)
        {
            ArrowTransform.rotation = Quaternion.Euler(0, 0, 180);
            Showel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 30, 0);
        }
        else if (ValueI < Player.instance.PlayerTileI)
        {
            ArrowTransform.rotation = Quaternion.Euler(0, 0, 270);
            Showel.GetComponent<RectTransform>().anchoredPosition = new Vector3(-30, 0, 0);
        }
        else if (ValueI > Player.instance.PlayerTileI)
        {
            ArrowTransform.rotation = Quaternion.Euler(0, 0, 90);
            Showel.GetComponent<RectTransform>().anchoredPosition = new Vector3(30, 0, 0);
        }
    }

    // I == x
    // J == y

    bool PlayerOnthisBlock()
    {
        return ValueI == Player.instance.PlayerTileI && ValueJ == Player.instance.PlayerTileJ;
    }

}
