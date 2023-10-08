using System.Collections.Generic;
using UnityEngine;

public class TreasureBoard
{
    private int width;
    private int height;
    private Vector2 originPosition;
    private const int CELL_SIZE = 5;

    public int TotalTreasures => totalTreasures;
    private int totalTreasures;
    private Grid<Island> grid;
    private List<Island> treasureIslands;

    public TreasureBoard(int width, int height, Vector3 originPosition, int cellSize, int totalTreasures)
    {
        this.grid = new Grid<Island>(width, height, cellSize, originPosition, (Grid<Island> g, int x, int y) => new Island(g, x, y));
        this.width = width;
        this.height = height;
        this.originPosition = originPosition;
        this.totalTreasures = totalTreasures;

        RequestRandomTreasures();
    }

    private void RequestRandomTreasures()
    {
        // TODO: replace this function with random from the server and sends to client


    }

    public Grid<Island> GetGrid() => grid;
}
