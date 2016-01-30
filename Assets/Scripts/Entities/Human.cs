using UnityEngine;
using System.Collections;

public abstract class Human : Entity {
	
	public enum Item {NULL, SWORD, AXE, PICKAXE}
	
	public Item item;
	
	public bool hasHarvestTool(){
		return item == Item.AXE || item == Item.PICKAXE;
	}
}