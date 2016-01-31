 using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    bool easy;
    int human = 0;
    bool hard;
    int animal = 0;
    bool medium;
    int ns;
    int resource = 0;
    bool hardest;


    public void easyMode() {
        human += 2;
        print("you have to  kill " + human + " humans");
    }

    public void mediumMode() {
        animal += 4;
        print("you have to  kill " + animal + " animals");
    }

    public void hardMode() {
        resource += 6;
        print("you have  " + resource + " resource");
    }

    public void hardestMode() {
        ns += 8;
        print("you have  " + ns + " no sacrifice  ");
    }
}
