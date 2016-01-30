using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
	
	[SerializeField]
	private float health, maxHealth;
	
	public float getHealth(){
		return health;
	}
	
	public void addHealth(float amount){
		health += amount;
	}
	
	void Start(){
		health = maxHealth;
	}
}