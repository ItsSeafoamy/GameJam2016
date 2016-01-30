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
        easy = Input.GetKeyDown(KeyCode.E);
        if (easy) {
            human += 2;
            print("you have to  kill " + human + " hummans");
        }
    }

    public void mediumMode() {
        medium = Input.GetKeyDown(KeyCode.M);
        if (medium) {
            animal += 4;
            print("you have to  kill " + animal + " animasl");
        }
    }

    public void hardMode() {
        hard = Input.GetKeyDown(KeyCode.H);
        if (hard) {
            resource += 6;
            print("you have  " + resource + " resource");
        }
    }

    public void hardestMode() {
        hardest = Input.GetKeyDown(KeyCode.A);
        if (hardest) {
            ns += 8;
            print("you have  " + ns + " no sacerfise  ");
        }
    }

}
