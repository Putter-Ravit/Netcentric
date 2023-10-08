using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island
{
    private Grid<Island> grid;

    public int x;
    public int y;
    private bool isSearched;
    public bool IsSearched => isSearched;
    private bool hasTreasure;
    public bool HasTreasure => hasTreasure;

    public Island(Grid<Island> grid, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;

        isSearched = false;
        hasTreasure = false;
    }

    public void SetTreasure(bool value) => hasTreasure = value;

    public Grid<Island> GetGrid() => grid;

    public override string ToString()
    {
        return $"{x} , {y}";
    }
}
