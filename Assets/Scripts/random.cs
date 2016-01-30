using UnityEngine;
using System.Collections;

public class random : MonoBehaviour {

    void Start() {
        string resourceName = "";
        int resource = Randmisation(0,5);

        if (resource == 0) {
            resourceName = "water";
        }

        if (resource == 1) {
            resourceName = "food";
        }

        if (resource == 2) {
            resourceName = "money";
        }

        if (resource == 3) {
            resourceName = "wood";
        }

        if (resource == 4) {
            resourceName = "stone";
        }

        int amount = Randmisation(0,100);
        print(amount + " of " + resourceName);
    }

    int Randmisation(int min, int max) {
        return Random.Range(min, max);
    }
}
