using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour {
    Transform mesh;
    public LayerMask tileLayer;
    public static Vector3 MousePosition { get; private set; }
    

	void Start () {
        mesh = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        mesh.Rotate(0, 1, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            //transform.position = hit.point;
            Node node = GameController.Grid.NodeFromWorldPosition(hit.point);

            transform.position = node.worldPosition;
            MousePosition = transform.position;

            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (GameController.placingObject != null) {

                    GameController.placingObject.transform.position = MousePosition;
                    if (Input.GetMouseButtonDown(0)) {

                        if (node.active) {
                            GameController.placingObject.transform.position = node.worldPosition;
                            node.active = false;
                            GameController.placingObject = null;
                        }

                    }

                }
            }
        }
	}


}
