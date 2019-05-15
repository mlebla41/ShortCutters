using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    public Vector2 worldPosition;
    public bool walkable;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public Node parent;

    public Node(bool _walkable, Vector2 pos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = pos;
        gridX = _gridX;
        gridY = _gridY;
    }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
