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
		
		if (health <= 0){
			//TODO: Something on death?
			Destroy(gameObject);
		}
	}
	
	void Start(){
		health = maxHealth;
	}
}