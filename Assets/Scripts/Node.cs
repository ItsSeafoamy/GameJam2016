using UnityEngine;
using System.Collections;

public class Node {

    public Vector3 worldPosition;
    public bool active;
    public int gridX, gridY;

    public Node(Vector3 position, bool isActive, int _gridX, int _gridY) {
        worldPosition = position;
        active = isActive;
        gridX = _gridX;
        gridY = _gridY;
    }

}
