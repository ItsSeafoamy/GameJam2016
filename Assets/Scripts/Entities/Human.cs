using UnityEngine;
using System.Collections;

public abstract class Human : Entity {

    protected AudioSource source;

	public enum Item {NULL, SWORD, AXE, PICKAXE, BOW}
	
	public Item item;
	
	public float attack;
	
    protected void Start() {
        source = GetComponent<AudioSource>();
    }

	public bool hasHarvestTool(){
		return item == Item.AXE || item == Item.PICKAXE;
	}
	
	public bool hasAttackingTool(){
		return item == Item.SWORD || item == Item.BOW;
	}
}