using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
	
#pragma warning disable 0649
	[SerializeField]
	public float maxHealth;
    public float health;
#pragma warning restore 0649

    public abstract string getName();
	
	public float getHealth(){
		return health;
	}

    public void SetHealth(int i){
        health = i;
	}

    public void ResetHealth(){
        health = maxHealth;
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