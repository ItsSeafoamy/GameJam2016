using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour {
    Transform mesh;
    public LayerMask tileLayer;
    public static Vector3 MousePosition { get; private set; }
    GameController control;


    void Start() {
        mesh = transform.GetChild(0);
        control = FindObjectOfType<GameController>();
    }

    void Update() {
        mesh.Rotate(0, 1, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, ~((1 << 0x0A) | (1 << 0x02)))) {
            Node node = hit.collider.GetComponent<Node>();

            if (node != null) {
                transform.position = node.transform.position;
                MousePosition = transform.position;

                if (!EventSystem.current.IsPointerOverGameObject()) {
                    if (GameController.placingObject != null) {

                        GameController.placingObject.transform.position = MousePosition;
                        if (Input.GetMouseButtonDown(0)) {

                            if (node.active) {
                                GameController.placingObject.transform.position = node.transform.position;
                                if (GameController.placingObject.GetComponent<Building>().type == Building.Type.WOOD_TOWER)
                                    control.AddVillagerMaxHealth(2);
                                else
                                    if (GameController.placingObject.GetComponent<Building>().type == Building.Type.STONE_TOWER)
                                    control.AddVillagerDamage(2);

                                GameController.placingObject.layer = 0x0A;
                                node.active = false;
                                GameController.placingObject = null;
                            }
                        }
                    }
                }
            }
        }
    }
}
