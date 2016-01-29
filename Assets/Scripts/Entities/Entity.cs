using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
	
	private float health, maxHealth;
	
	private abstract float getMaxHealth();
	
	public float getHealth(){
		return health;
	}
	
	public void addHealth(float amount){
		health += amount;
	}
}