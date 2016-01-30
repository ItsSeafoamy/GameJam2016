using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public static bool InputEnabled { get; set; }
    public static TownGrid Grid { get; set; }

    public Text text;
    public GameObject woodenTower, stoneTower, building;
    public static GameObject placingObject;

    public void ChangeScene(string scene) {
        StartCoroutine(LoadingScreen.ChangeScene(scene));
    }

    public void SpawnWoodenTower() {
        placingObject = (GameObject)Instantiate(woodenTower, Mouse.MousePosition, Quaternion.identity);
        text.text = "WoodenTower";
    }

    public void SpawnStoneTower() {
        placingObject = (GameObject)Instantiate(stoneTower, Mouse.MousePosition, Quaternion.identity);
        text.text = "StoneTower";
    }

    public void SpawnBuilding() {
        placingObject = (GameObject)Instantiate(building, Mouse.MousePosition, Quaternion.identity);
        text.text = "Building";
    }


}
