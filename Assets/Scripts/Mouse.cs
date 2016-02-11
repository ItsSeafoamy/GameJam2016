using UnityEngine;

public class Mouse : MonoBehaviour {
    Transform mesh;
    public LayerMask tileLayer;
    public static Vector3 MousePosition { get; private set; }

    void Start() {
        mesh = transform.GetChild(0);
    }

    void Update() {
        mesh.Rotate(0, 1, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, ~((1 << 0x0A) | (1 << 0x02) | (1 << 0x05)))) {
            Node node = hit.collider.GetComponent<Node>();

            if (node != null) {
                transform.position = node.transform.position;
                MousePosition = transform.position;

                if (GameController.placingObject != null) {

                    GameController.placingObject.transform.position = MousePosition;
                    if (Input.GetMouseButtonDown(0)) {

                        if (node.active) {
                            Building building = GameController.placingObject.GetComponent<Building>();
                            building.Build(node);

                            GameController.placingObject = null;
                        }
                    }
                }
            }
        }
    }
}
