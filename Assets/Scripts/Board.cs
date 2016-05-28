using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.UI;

public class Board : MonoBehaviour {

    List<List <Block>> Blocks = new List<List<Block>>();
    [SerializeField]
    GameObject BlockPrefab;
    public int BoardWidth;
    public int BoardHeight;
    public List<Sprite> Sprites;
    public List<Block.Item> Items;

    public int NumberOfKeys = 3;
    public int NumberOfGems = 7;
    
    public static int Size = 250;

    public static Board instance;

    public void Generate(int Width, int Height)
    {
        int OneDimIndex = 0;

        for (int i = 0 ; i < Width ; i++)
        {
            Blocks.Add(new List<Block>());
            for (int j = 0; j < Height; j++)
            {
                var InstantiatedBlock = Instantiate(BlockPrefab);
                InstantiatedBlock.transform.position = new Vector3((i * Size) - ((BoardWidth * Size)/2) + 50/* + Screen.width / 7*/, (j * Size) - ((BoardHeight * Size) / 2) + Screen.height / 500, 0);
                InstantiatedBlock.GetComponent<Block>().ValueI = i;
                InstantiatedBlock.GetComponent<Block>().ValueJ = j;
                Blocks[i].Add(InstantiatedBlock.GetComponent<Block>());
                InstantiatedBlock.transform.SetParent(transform, false);
                InstantiatedBlock.GetComponent<Block>().BlockImage.GetComponent<Image>().sprite = Sprites[OneDimIndex];
                InstantiatedBlock.GetComponent<Block>().ContainsItem = Items[OneDimIndex];
                OneDimIndex++;
            }
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Start ()
	{
	    GenerateRandomItems();
        Generate(BoardWidth, BoardHeight);
	}
	
	void Update () {
	
	}


    void GenerateRandomItems()
    {
        for (int i = 0; i < 20; ++i)
        {
            Items.Add(Block.Item.None);
        }
        var keysPos = new List<int>();
        var gemsPos = new List<int>();

        while (keysPos.Count < NumberOfKeys)
        {
            int newPos = Random.Range(0, 20);
            
            if (!keysPos.Contains(newPos))
            {
                keysPos.Add(newPos);
            }
        }

        while (gemsPos.Count < NumberOfGems)
        {
            int newPos = Random.Range(0, 20);

            if (!keysPos.Contains(newPos) && !gemsPos.Contains(newPos))
            {
                gemsPos.Add(newPos);
            }
        }

        for (int i = 0; i < keysPos.Count; ++i)
        {
            Items[keysPos[i]] = Block.Item.Key;
        }

        for (int i = 0; i < gemsPos.Count; ++i)
        {
            Items[gemsPos[i]] = (Block.Item)Random.Range(2,5);
        }
    }

    public void ShowAllItems()
    {
        if (!GameState.ItemIsMoving)
        {
            for (int i = 0; i < Blocks.Count; ++i)
            {
                for (int j = 0; j < Blocks[i].Count; ++j)
                {
                    Blocks[i][j].ShowItem();
                }
            }
        }
    }
}
