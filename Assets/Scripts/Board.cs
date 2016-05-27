using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {

    List<List <Block>> Blocks = new List<List<Block>>();
    [SerializeField]
    GameObject BlockPrefab;
    public int BoardWidth;
    public int BoardHeight;
    
    public int Size = 32;

    public void Generate(int Width, int Height)
    {
        for (int i = 0 ; i < Width ; i++)
        {
            Blocks.Add(new List<Block>());
            for (int j = 0; j < Height; j++)
            {
                var InstantiatedBlock = Instantiate(BlockPrefab);
                InstantiatedBlock.transform.position = new Vector3((i * Size) - ((BoardWidth * Size)/2) + Screen.width / 2, (j * Size) - ((BoardHeight * Size) / 2) + Screen.height / 2, 0);
                InstantiatedBlock.GetComponent<Block>().ValueI = i;
                InstantiatedBlock.GetComponent<Block>().ValueJ = j;
                Blocks[i].Add(InstantiatedBlock.GetComponent<Block>());
                InstantiatedBlock.transform.parent = transform;
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
