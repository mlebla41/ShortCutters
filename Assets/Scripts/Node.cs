using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    public Vector2 worldPosition;
    public bool walkable;

    public Node(bool _walkable, Vector2 pos)
    {
        walkable = _walkable;
        worldPosition = pos;
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
