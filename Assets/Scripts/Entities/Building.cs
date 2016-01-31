using UnityEngine;
using System.Collections;
using System;

public class Building : Entity {

    public enum Type {WOOD_TOWER, STONE_TOWER, QUARRY, LOG, BUILDING}
    public Type type;

    public override string getName() {
        if (type == Type.WOOD_TOWER) return "Wood Tower";
        else if (type == Type.STONE_TOWER) return "Stone Tower";
        else if (type == Type.LOG) return "Log Pile";
        else if (type == Type.QUARRY) return "Quarry";
        else if (type == Type.BUILDING) return "Building";
        throw new NotImplementedException();
    }
}