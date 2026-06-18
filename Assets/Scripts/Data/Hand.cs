using UnityEngine;
using System.Collections.Generic;

public class Hand
{
    private List<PaiType> tiles = new();

    public IReadOnlyList<PaiType> Tiles => tiles;

    public void Add(PaiType tile)
    {
        tiles.Add(tile);
    }

    public bool Remove(PaiType tile)
    {
        return tiles.Remove(tile);
    }

    public void Sort()
    {
        tiles.Sort();
    }

    public void Clear()
    {
        tiles.Clear();
    }

    public int Count => tiles.Count;
}
