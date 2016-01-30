using UnityEngine;
using System.Collections;

public class TownGrid : MonoBehaviour {

    public Vector2 gridWorldSize;
    public float nodeRadius;
    public GameObject tilePrefab;

    Node[] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    void Awake() {
        GameController.Grid = this;
        nodeDiameter = 2 * nodeRadius;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    public int MaxSize {
        get {
            return gridSizeX * gridSizeY;
        }
    }

    void CreateGrid() {
        grid = new Node[gridSizeX * gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++) {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);

                GameObject tile = (GameObject)Instantiate(tilePrefab, worldPoint, Quaternion.identity);
                tile.transform.parent = transform;
                grid[x + y * gridSizeX] = tile.GetComponent<Node>();
            }
        }
    }

    //public Node NodeFromWorldPosition(Collider collider) {
    //    //float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
    //    //float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
    //    //percentX = Mathf.Clamp01(percentX);
    //    //percentY = Mathf.Clamp01(percentY);

    //    //int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
    //    //int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

    //    if (collider == null) return null;

    //    foreach (Node n in grid) {
    //        if (n.worldPosition.x == collider.transform.position.x && n.worldPosition.z == collider.transform.position.z) {
    //            return n;
    //        }
    //    }

    //    return null;
    //}

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null) {
            foreach (Node n in grid) {
                //Gizmos.color = (n.active) ? Color.blue : Color.red;
                //Gizmos.DrawCube(n.worldPosition, Vector3.one * 0.9f);
            }
        }
    }

}
