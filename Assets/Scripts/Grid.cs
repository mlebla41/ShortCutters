using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public bool displayGridGizmos;
    public Transform player;
    Node[,] grid;
    public Vector2 gridSize;
    public float nodeRadius;
    public LayerMask unwalkableMask;

    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    public List<Node> path;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(gridSize.x, gridSize.y));
        Node playerNode = NodeFromWorldPoint(player.position);
        if (grid != null && displayGridGizmos)
        {
            foreach(Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                if (path != null)
                    if (path.Contains(n))
                        Gizmos.color = Color.cyan;
                if (playerNode == n)
                {
                    Gizmos.color = Color.green;
                }
                Gizmos.DrawCube(n.worldPosition, Vector2.one * (nodeDiameter - .1f));
            }
        }
    }

    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridSize.y / nodeDiameter);
        CreateGrid();
    }
    void CreateGrid()
    {
        grid = new Node[gridSizeX,gridSizeY];
        Vector2 botLeft = (Vector2)transform.position - Vector2.right * gridSize.x / 2 - Vector2.up * gridSize.y / 2;

        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector2 worldPoint = botLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius/2, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint,x,y);
            }
        }
    }
    public Node NodeFromWorldPoint(Vector2 worldPosition)
    {
        float percentX = (worldPosition.x + gridSize.x / 2) / gridSize.x;
        float percentY = (worldPosition.y + gridSize.y / 2) / gridSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x,y];
    }

    public List<Node> GetNeighbors(Node node)
    {
        List<Node> Neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    Neighbors.Add(grid[checkX, checkY]);
                }

            }

        }

        return Neighbors;
    }
}
