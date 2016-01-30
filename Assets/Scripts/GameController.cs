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
    public AudioSource audioSource;
    public AudioClip[] musicTrack;
    public Text explorationText;
    public Exploration exploration;

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
            
        if (Game.wood >= 2){
        	placingObject = (GameObject)Instantiate(woodenTower, Mouse.MousePosition, Quaternion.identity);
        	text.text = "WoodenTower";
            Game.wood -= 2;
        } else {
        	text.text = "You need " + (2-Game.wood) + " more wood to build this";
        }
    }
    public void SpawnStoneTower() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);
            
        if (Game.stone >= 2){
       	 	placingObject = (GameObject)Instantiate(stoneTower, Mouse.MousePosition, Quaternion.identity);
        	text.text = "StoneTower";
            Game.stone -= 2;
        } else {
        	text.text = "You need " + (2-Game.stone) + " more stone to build this";
        }
    }
    public void SpawnBuilding() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);

        if (Game.wood >= 3 && Game.stone >= 2) {
            placingObject = (GameObject)Instantiate(building, Mouse.MousePosition, Quaternion.identity);
            text.text = "Building";
            Game.wood -= 3;
            Game.stone -= 2;
        }
        else
            text.text = "You need " + (2 - Game.stone) + " more stone and " + (3 - Game.wood) + " more wood to build this";
    }
    public void SpawnQuarry() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);

        if (Game.stone >= 10) {
            placingObject = (GameObject)Instantiate(quarry, Mouse.MousePosition, Quaternion.identity);
            text.text = "Quarry";
            Game.stone -= 10;
        }
        else
            text.text = "You need " + (10 - Game.stone) + " more stone to build this";
    }
    public void SpawnLogPost() {
        if (placingObject != null)
            Destroy(placingObject.gameObject);

        if (Game.wood >= 10) {
            placingObject = (GameObject)Instantiate(logPost, Mouse.MousePosition, Quaternion.identity);
            text.text = "Logging Post";
            Game.wood -= 10;
        }
        else
            text.text = "You need " + (10 - Game.wood) + " more wood to build this";
    }

    public void ShowRitualScreen() {
        ritualScreen.SetActive(true);
    }
    public void HideRitualScreen() {
        ritualScreen.SetActive(false);
    }

    public void ShowBuildOptions() {
        buildoptions.SetActive(true);
        HideExplorationOptions();
    }
    public void HideBuildOptions() {
        buildoptions.SetActive(false);
    }

    public void ShowExplorationOptions() {
        exploreBuildButton.SetActive(true);
    }
    public void HideExplorationOptions() {
        exploreBuildButton.SetActive(false);
    }

    public void SwitchAudioTrack(int i) {
        float timestamp = audioSource.time;
        audioSource.clip = musicTrack[i];
        audioSource.time = timestamp;
        audioSource.Play();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E))
            SwitchAudioTrack(1);
        if (Input.GetKeyDown(KeyCode.Q))
            SwitchAudioTrack(0);
    }

    public void Explore() {
        explorationText.gameObject.SetActive(true);
        explorationText.text = exploration.Explore();
        StartCoroutine("Wait");
    }

    IEnumerator Wait() {


        yield return new WaitForSeconds(3);


        explorationText.gameObject.SetActive(false);
        ProgressDay();
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

        SwitchAudioTrack(day);

        if (day == 7) {
            ShowRitualScreen();
            print("Run attack code here pls thank");
        }
        else {
            ShowExplorationOptions();
            HideBuildOptions();
        }
        text.text = "Day: " + day;
    }
}
