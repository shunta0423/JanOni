using UnityEngine;
using System.Collections.Generic;

public class Hand
{
    private List<PaiType> tiles = new();
    
    public IReadOnlyList<PaiType> Tiles => tiles;

    public void Add(PaiType pai)
    {
        tiles.Add(pai);
    }

    public void Remove(int n)
    {
        tiles.RemoveAt(n);
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
