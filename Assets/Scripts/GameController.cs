using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public static bool InputEnabled { get; set; }
    public static TownGrid Grid { get; set; }

    public Text text;
    public Transform directionalLight;
    public GameObject woodenTower, stoneTower, building, quarry, logPost;
    public GameObject enemySword, enemyBow;
    public GameObject ritualScreen;
    public GameObject exploreBuildButton;
    public GameObject buildoptions;
    public GameObject[] ritualButtons;
    public AudioSource audioSource;
    public AudioClip[] musicTrack;
    public Text explorationText;
    Exploration exploration;
    Difficulty difficulty;
    public Text detailName;
    public Text sacrificeBtn;
    public GameObject details;
    public LayerMask villagerLayer;
    Enemy[] enemies;
    Villager[] villagers;

    //Attack happens on day 7
    static int day = 1; //Why dis start at 1 (>﹏<) //Cos you start on day one silly!
    static int week = 0;
    public Transform[] enemySpawns;
    public static GameObject placingObject;
    public int woodCost, stoneCost;

    public int atkVil, othVil, stone, wood;
    public Text woodCount, stoneCount;

    private float target = 0;
    private bool awaitingRitual;

    private Entity selected;

    void Start() {
        exploration = GetComponent<Exploration>();
        difficulty = GetComponent<Difficulty>();
        InputEnabled = true;
    }

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

    public void AddVillagerMaxHealth(int h) {
        villagers = FindObjectsOfType<Villager>();

        foreach (Villager v in villagers)
            v.maxHealth = v.maxHealth + h;
    }

    public void AddVillagerDamage(int d) {
        villagers = FindObjectsOfType<Villager>();

        foreach (Villager v in villagers)
            v.attack = v.attack + d;
    }

    void Update() {
        if (woodCount != null)
            woodCount.text = Game.wood.ToString();

        if (stoneCount != null)
            stoneCount.text = Game.stone.ToString();

        if (Input.GetMouseButtonDown(0) && InputEnabled) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, /*villagerLayer))/**/ (1 << 0x09) | (1 << 0x0A))){
                selected = hit.collider.GetComponent<Entity>();
                if(selected!=null)
                detailName.text = selected.getName();

                //details.SetActive(true);

                if (selected is Villager) {

                }
            } else {
                selected = null;
                //details.SetActive(false);
            }
        }

        if (day == 7) {
            if (!awaitingRitual)
                Attack();
        }
    }

    public void Explore() {
        if (InputEnabled) {
            explorationText.gameObject.SetActive(true);
            explorationText.text = exploration.Explore();
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait() {
        InputEnabled = false;
        yield return new WaitForSeconds(3);

        explorationText.gameObject.SetActive(false);
        ProgressDay();
        InputEnabled = true;
    }

    IEnumerator GameOver() {
        InputEnabled = false;
        explorationText.gameObject.SetActive(true);
        explorationText.text = "The Village is Dead";
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("MainMenu");
    }

    //void FadeIn(int i) {
      // if (audioChannels[i].volume < 1)
          // audioChannels[i].volume += 1 * Time.deltaTime;
   // }

    //void FadeOut(int i) {
      //  if (audioChannels[i].volume > 1)
        //    audioChannels[i].volume -= 1 * Time.deltaTime;
    //}

    public void HumanSacrifice() {
       // Debug.Break();
        print("Humans Sacrificed");
        
        villagers = FindObjectsOfType<Villager>();

        int random = Random.Range(0, villagers.Length - 1);
        villagers[random].addHealth(-1000);

        difficulty.SetAttack(0);
        StartAttack(0);
        HideRitualScreen();
    }

    public void AnimalSacrifice() {
        HideRitualScreen(); 
    }

    public void WoodSacrifice() {
        print("Wood Sacrificed");

        int random = Random.Range(0, 1);

        print(difficulty.wood);
        if (Game.wood >= difficulty.wood) {
            Game.wood -= difficulty.wood;
            difficulty.SetAttack(1);
            StartAttack(1);
            HideRitualScreen();
        }
        else
            StartCoroutine("ShowText", "Not enough wood");
    }

    public void StoneSacrifice() {
        print("Wood Sacrificed");

        int random = Random.Range(0, 1);

        if(Game.stone >= difficulty.stone) {
            Game.stone -= difficulty.stone;
            difficulty.SetAttack(2);
            StartAttack(2);
            HideRitualScreen();
        }
        else
            StartCoroutine("ShowText", "Not enough stone");
    }

    IEnumerator ShowText(string text) {
        explorationText.gameObject.SetActive(true);
        explorationText.text = text;
        yield return new WaitForSeconds(1);
        explorationText.gameObject.SetActive(false);
    }

    public void NoSacrifice() {
        print("No Sacrifice");
        HideRitualScreen();
        difficulty.SetAttack(3);
        StartAttack(3);
    }

    public void Sacrifice() {
        if (selected is Villager) {

        }
    }

    public void ProgressDay() {
        if (day == 7) {
            day = 1;
            week++;
        }
        else {
            day++;
            ResourceGeneration[] gen = FindObjectsOfType<ResourceGeneration>();
            foreach(ResourceGeneration r in gen) {
                r.GenerateResource();
            }
            print("Generate");
        }

        SwitchAudioTrack(day-1);

        if (day == 7) {
            HideBuildOptions();

            target = Mathf.Pow(week+1, 1.5f);

            text.text = "Select Villagers or resources to sacrifice";
            awaitingRitual = true;
            ShowRitualScreen();
            HideExplorationOptions();
            sacrificeBtn.text = "Sacrifice";
            
        }
        else {
            ShowExplorationOptions();
            HideBuildOptions();

            sacrificeBtn.text = "You can't sacrifice yet";
        }
        text.text = "Day: " + day;
    }

    public void StartAttack(int i) {
        print("Starting attack");
        int random;
        Vector3 pos;
        float minX =-9;
        float maxX = 9;
        float minZ = -9;
        float maxZ = 9;
        switch (i) {
            case 0:
                for (int e = 0; e < 2 + difficulty.human; e++) {
                    random = Random.Range(0, 1);
                    if (random == 0) {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        Instantiate(enemySword, pos, Quaternion.identity);
                    }
                    else {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        Instantiate(enemyBow, pos, Quaternion.identity);
                    }
                }
                break;
            case 1:
                for (int e = 0; e < 5 + difficulty.wood; e++) {
                    random = Random.Range(0, 1);
                    if (random == 0) {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        Instantiate(enemySword, pos, Quaternion.identity);
                    }
                    else {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        Instantiate(enemyBow, pos, Quaternion.identity);
                    }
                }
                break;
                 case 2:
                for (int e = 0; e < 5 + difficulty.stone; e++) {
                    random = Random.Range(0, 1);
                    if (random == 0) {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        Instantiate(enemySword, pos, Quaternion.identity);
                    }
                    else {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        Instantiate(enemyBow, pos, Quaternion.identity);
                    }
                }
                break;
            case 3:
                for (int e = 0; e < 8 + difficulty.ns; e++) {
                    random = Random.Range(0, 1);
                    if (random == 0) {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        print("Spawn enemy pls");
                        Instantiate(enemySword, pos, Quaternion.identity);
                    }
                    else {
                        pos = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
                        print("Spawn enemy pls");
                        Instantiate(enemyBow, pos, Quaternion.identity);
                    }
                }
                break;
        }
        awaitingRitual = false;
    }

    public void Attack() {
        enemies = FindObjectsOfType<Enemy>();
        villagers = FindObjectsOfType<Villager>();

        if (enemies.Length == 0) {
            foreach (Villager v in villagers)
                v.ResetHealth();
            ProgressDay();
        }
        if (villagers.Length == 0) {
            print("GAME OVER");
            StartCoroutine("GameOver");
        }
    }

    void Awake() {
		audioSource = GetComponent<AudioSource> ();
	}
}