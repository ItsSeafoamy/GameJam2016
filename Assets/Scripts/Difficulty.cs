 using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {

    public int human = 1;
    int animal = 0;
    public int ns;
    public int wood = 6;
    public int stone = 6;

    public void SetAttack(int i) {
        switch (i) {
            case 0:
                easyMode();
                break;
            case 1:
                SacrificeWood();
                break;
                case 2:
                SacrificeStone();
                break;
            case 3:
                hardestMode();
                break;
        }
    }

    public void easyMode() {
        human += 1;
        print("you have to  kill " + human + " humans");
    }

    public void mediumMode() {
        animal += 4;
        print("you have to  kill " + animal + " animals");
    }

    public void SacrificeWood() {
        wood += 3;
        print("you have  " + wood + " resource");
    }
    public void SacrificeStone() {
        stone += 3;
        print("you have  " + stone + " resource");
    }

    public void hardestMode() {
        ns += 8;
        print("you have  " + ns + " no sacrifice  ");
    }
}
