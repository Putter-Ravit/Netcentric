using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private TreasureBoard treasureBoard;

    [SerializeField]
    private Transform origin;

    [SerializeField]
    private Sprite sprite;
    private int cellSize = 5;

    private bool isBoardCreated = false;

    void Start()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isBoardCreated)
        {
            CreateBoard(6, 6, cellSize, 11);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Utils.UtilsClass.GetMouseWorldPosition2D();

            if (treasureBoard == null) return;

            var clickedIsland = treasureBoard.GetGrid().GetGridObject(mousePos);

            if (clickedIsland != null)
            {
                Debug.Log($"Clicked on island {clickedIsland.x}, {clickedIsland.y}");
            }
        }
    }

    public void CreateBoard(int width, int height, int cellSize, int totalTreasures)
    {
        treasureBoard = new TreasureBoard(width, height, origin.position, cellSize, totalTreasures);
        CreateBoardVisual(width, height);
        isBoardCreated = true;
    }

    private void CreateBoardVisual(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 pos = treasureBoard.GetGrid().GetWorldPosition(x, y);
                SpawnIsland(pos);
            }
        }
    }

    private Transform SpawnIsland(Vector2 pos)
    {
        GameObject island = new GameObject("Island", typeof(SpriteRenderer));
        island.GetComponent<SpriteRenderer>().sprite = sprite;
        island.transform.parent = origin;
        pos += new Vector2((float)cellSize / 2, (float)cellSize / 2);
        island.transform.position = pos;
        return island.transform;
    }
}
