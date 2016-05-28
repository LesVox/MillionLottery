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
    public bool IsAdjacent = false;
    public List<GameObject> ItemsToSpawn;

    public enum Item
    {
        None, Key, Gem
    }

    public Item ContainsItem = Item.None;

    public Image Arrow;
    private RectTransform ArrowTransform;
	private TileDigAnimation tileDig;
	private int previousSteps;

    void Start()
    {
        ArrowTransform = Arrow.GetComponent<RectTransform>();
		tileDig = GetComponentInChildren<TileDigAnimation> ();
		previousSteps = Player.instance.Steps;
    }

    public void MovePlayer()
    {
        if (IsAdjacent)
        {
			
			previousSteps = Player.instance.Steps;
			Player.instance.Move(transform.position, this);
            
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
        if (Player.instance.Starting && ValueJ == 4 || Mathf.Abs(Player.instance.PlayerTileI - ValueI) == 1 && Mathf.Abs(Player.instance.PlayerTileJ - ValueJ) == 0 || Mathf.Abs(Player.instance.PlayerTileJ - ValueJ) == 1 && Mathf.Abs(Player.instance.PlayerTileI - ValueI) == 0)
        {
            IsAdjacent = true;
        }
        else
        {
            IsAdjacent = false;
        }
    }

    void Update()
    {
        CheckAdjacent();
        if (IsAdjacent && !Player.instance.IsMoving && Player.instance.Steps > 0)
        {
            Arrow.enabled = true;
            RotateArrow();
        }
        else
        {
            Arrow.enabled = false;
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
			item.transform.SetParent(Front.instance.transform, false);
            item.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position + new Vector3( /*(float)Board.Size / 2*/ 40, /*(float)Board.Size / 2*/40, 0);
            item.GetComponent<MoveItem>().ItemFound = ItemFound;
        }
    }

    public void ShowItem()
    {
        InstantiateItem(false);
        GetComponent<Image>().enabled = false;
    }

    void RotateArrow()
    {
        if (ValueJ < Player.instance.PlayerTileJ)
        {
            ArrowTransform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (ValueJ > Player.instance.PlayerTileJ)
        {
            ArrowTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (ValueI < Player.instance.PlayerTileI)
        {
            ArrowTransform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (ValueI > Player.instance.PlayerTileI)
        {
            ArrowTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    // I == x
    // J == y

    bool PlayerOnthisBlock()
    {
        return ValueI == Player.instance.PlayerTileI && ValueJ == Player.instance.PlayerTileJ;
    }

}
