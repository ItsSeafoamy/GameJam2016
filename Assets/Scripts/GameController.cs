using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public static bool InputEnabled { get; set; }
    public static TownGrid Grid { get; set; }

    public Text text;
    public Transform directionalLight;
    public GameObject woodenTower, stoneTower, building, quarry, logPost;
    public GameObject enemy;
    public GameObject ritualScreen;
    public GameObject exploreBuildButton;
    public GameObject buildoptions;
    public GameObject[] ritualButtons;

    //Attack happens on day 7
    static int day = 1;
    public Transform[] enemySpawns;
    public static GameObject placingObject;
    public int woodCost, stoneCost;


    public void ChangeScene(string scene) {
        StartCoroutine(LoadingScreen.ChangeScene(scene));
    }

    public void SpawnWoodenTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
            
        if (Game.wood >= woodCost){
        	placingObject = (GameObject)Instantiate(woodenTower, Mouse.MousePosition, Quaternion.identity);
        	text.text = "WoodenTower";
        } else {
        	text.text = "You need " + (woodCost-Game.wood) + " more wood to build this";
        }
    }
    public void SpawnStoneTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
            
        if (Game.stone >= stoneCost){
       	 	placingObject = (GameObject)Instantiate(stoneTower, Mouse.MousePosition, Quaternion.identity);
        	text.text = "StoneTower";
        } else {
        	text.text = "You need " + (stoneCost-Game.stone) + " more stone to build this";
        }
    }
    public void SpawnBuilding() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
            
        placingObject = (GameObject)Instantiate(building, Mouse.MousePosition, Quaternion.identity);
        text.text = "Building";
    }
    public void SpawnQuarry() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
            
        placingObject = (GameObject)Instantiate(quarry, Mouse.MousePosition, Quaternion.identity);
        text.text = "Quarry";
    }
    public void SpawnLogPost() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
            
        placingObject = (GameObject)Instantiate(logPost, Mouse.MousePosition, Quaternion.identity);
        text.text = "Logging Post";
    }

    public void ShowRitualScreen() {
        ritualScreen.SetActive(true);
    }
    public void HideRitualScreen() {
        ritualScreen.SetActive(false);
    }

    public void ShowBuildOptions() {
        buildoptions.SetActive(true);
    }
    public void HideBuildOptions() {
        buildoptions.SetActive(false);
    }

    //void FadeIn(int i) {
    //    if (audioChannels[i].volume < 1)
    //        audioChannels[i].volume += 1 * Time.deltaTime;
    //}

    //void FadeOut(int i) {
    //    if (audioChannels[i].volume > 1)
    //        audioChannels[i].volume -= 1 * Time.deltaTime;
    //}

    public void HumanSacrifice() {
        HideRitualScreen();
    }

    public void AnimalSacrifice() {
        HideRitualScreen();
    }

    public void ResourceSacrifice() {
        HideRitualScreen();
    }

    public void NoSacrifice() {
        HideRitualScreen();
    }

    public void ProgressDay() {
        if (day == 7) {
            day = 1;
            ResourceGeneration[] gen = FindObjectsOfType<ResourceGeneration>();
            foreach(ResourceGeneration r in gen) {
                r.GenerateResource();
            }
        }
        else
            day++;

        if (day == 7) {
            ShowRitualScreen();
            print("Run attack code here pls thank");
        }

        text.text = "Day: " + day;

    }
}
