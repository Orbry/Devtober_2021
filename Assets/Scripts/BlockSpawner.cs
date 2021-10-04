using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // total width of screen in units
    const float VIEWPORT_WIDTH = 36;
    // the coordinate of screen top in units
    const float VIEWPORT_TOP = 10;

    // gap between top of the screen and first row
    public float marginTop;
    // gap between screen sides and blocks
    public float marginSide;
    // gap between rows of blocks
    public float paddingVertical;
    // gap between blocks in a row
    public float paddingHorizontal;
    public int numberOfBlocks;
    public GameObject blockPrefab;

    private Transform m_transform;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    void Start()
    {
        SpawnBlocks();
    }
    
    private void SpawnBlocks()
    {
        
        float blockWidth = blockPrefab.transform.localScale.x;
        float blockHeight = blockPrefab.transform.localScale.y;

        int blocksPerRow = (int)((VIEWPORT_WIDTH - 2 * marginSide + paddingHorizontal) / (blockWidth + paddingHorizontal));
        int rows = numberOfBlocks / blocksPerRow;
        int remainder = numberOfBlocks % blocksPerRow;
        float rowMiddle = (blocksPerRow - 1) / 2f;
        float remainderMiddle = (remainder - 1) / 2f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < blocksPerRow; col++)
            {
                GameObject block = GameObject.Instantiate(blockPrefab);
                block.transform.parent = m_transform;

                float yPos = VIEWPORT_TOP - marginTop - row * (blockHeight + paddingVertical);
                float xPos = (col - rowMiddle) * (blockWidth + paddingHorizontal);

                block.transform.position = new Vector3(xPos, yPos);
            }
        }

        // positioning last not fully filled row in the middle of the screen below last full row
        for (int i = 0; i < remainder; i++)
        {
            GameObject block = GameObject.Instantiate(blockPrefab);
            block.transform.parent = m_transform;

            float yPos = VIEWPORT_TOP - marginTop - rows * (blockHeight + paddingVertical);
            float xPos = (i - remainderMiddle) * (blockWidth + paddingHorizontal);

            block.transform.position = new Vector3(xPos, yPos);
        }
    }
}
