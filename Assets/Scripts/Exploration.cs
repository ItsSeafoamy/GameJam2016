using UnityEngine;
using System.Collections;

public class Exploration : MonoBehaviour {

    public string Explore() { 
        string resourceName = "";
        int resource = Randomisation(1,2);
        int typesOfResources = Random.Range(1, 10);
        if (typesOfResources > 5)
            typesOfResources = 2;
        int amount = 0;

        resourceName = "Got ";

        if (resource == 1) {
            amount += Randomisation(1, 3);
            Game.wood += amount;
            resourceName += amount + " wood";

            if (typesOfResources == 2) {
                amount += Randomisation(1, 3);
                Game.stone += amount;
                resourceName += " and " + amount +" stone.";
            }
        }

        if (resource == 2) {
            amount += Randomisation(1, 3);
            Game.stone += amount;
            resourceName += amount + " stone";

            if (typesOfResources == 2) {
                amount += Randomisation(1, 3);
                Game.wood += amount;
                resourceName += " and" + amount +" wood.";
            }
        }
        return resourceName;
    }

    int Randomisation(int min, int max) {
        return Random.Range(min, max);
    }
}
