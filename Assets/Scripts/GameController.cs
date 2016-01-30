using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public static bool InputEnabled { get; set; }
    public static TownGrid Grid { get; set; }

    public Text text;
    public Transform directionalLight;
    public GameObject woodenTower, stoneTower, building;
    public GameObject enemy;

    //Attack happens on day 7
    static int days;

    public Transform[] enemySpawns;

    public static GameObject placingObject;

    public void ChangeScene(string scene) {
        StartCoroutine(LoadingScreen.ChangeScene(scene));
    }

    public void SpawnWoodenTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
        placingObject = (GameObject)Instantiate(woodenTower, Mouse.MousePosition, Quaternion.identity);
        text.text = "WoodenTower";
    }

    public void SpawnStoneTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
        placingObject = (GameObject)Instantiate(stoneTower, Mouse.MousePosition, Quaternion.identity);
        text.text = "StoneTower";
    }

    public void SpawnBuilding() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
        placingObject = (GameObject)Instantiate(building, Mouse.MousePosition, Quaternion.identity);
        text.text = "Building";
    }

    public static void SpawnEnemies(int difficulty) {

    }
}
