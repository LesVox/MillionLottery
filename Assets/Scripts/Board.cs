using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Board : MonoBehaviour {

    List<List <Block>> Blocks = new List<List<Block>>();
    [SerializeField]
    GameObject BlockPrefab;
    public int BoardWidth;
    public int BoardHeight;
    public List<Sprite> Sprites; 
    
    public int Size = 32;

    public void Generate(int Width, int Height)
    {
        int spriteIndex = 0;

        for (int i = 0 ; i < Width ; i++)
        {
            Blocks.Add(new List<Block>());
            for (int j = 0; j < Height; j++)
            {
                var InstantiatedBlock = Instantiate(BlockPrefab);
                InstantiatedBlock.transform.position = new Vector3((i * Size) - ((BoardWidth * Size)/2) + Screen.width / 2, (j * Size) - ((BoardHeight * Size) / 2) + Screen.height / 2, 0);
                Blocks[i].Add(InstantiatedBlock.GetComponent<Block>());
                InstantiatedBlock.transform.SetParent(transform);
                InstantiatedBlock.GetComponent<Image>().sprite = Sprites[spriteIndex];
                spriteIndex++;
            }
        }
    }

	// Use this for initialization
	void Start ()
    {
        Generate(BoardWidth, BoardHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
