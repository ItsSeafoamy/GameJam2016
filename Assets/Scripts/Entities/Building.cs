using UnityEngine;
using UnityEngine.UI;
using System;

public class Building : Entity {

    public enum Type {WOOD_TOWER, STONE_TOWER, QUARRY, LOG, BUILDING}
    public Type type;

    public Material builtMaterial;

    public enum CostType {WOOD, STONE}
    public CostType costType;
    public int cost;

    public override string getName() {
        if (type == Type.WOOD_TOWER) return "Wood Tower";
        else if (type == Type.STONE_TOWER) return "Stone Tower";
        else if (type == Type.LOG) return "Log Pile";
        else if (type == Type.QUARRY) return "Quarry";
        else if (type == Type.BUILDING) return "Building";
        throw new NotImplementedException();
    }

    public void Build(Node node) {
        GameController control = FindObjectOfType<GameController>();
        Text text = control.text;

        if (costType == CostType.WOOD && Game.wood < cost) {
            text.text = "You need " + (cost - Game.wood) + " more wood to build this";
            Destroy(gameObject);
        } else if (costType == CostType.STONE && Game.stone < cost) {
            text.text = "You need " + (cost - Game.stone) + " more stone to build this";
            Destroy(gameObject);
        } else {
            if (costType == CostType.WOOD)
                Game.wood -= cost;
            else if (costType == CostType.STONE)
                Game.stone -= cost;

            if (type == Type.WOOD_TOWER)
                control.AddVillagerMaxHealth(2);
            else if (type == Type.STONE_TOWER)
                control.AddVillagerDamage(2);

            GetComponent<Renderer>().material = builtMaterial;
            gameObject.layer = 0x0A;
            node.active = true;
            transform.position = node.transform.position;
        }
    }
}