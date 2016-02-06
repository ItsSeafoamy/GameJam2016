using UnityEngine;
using System.Collections;
//using System;

public class Enemy : Human {

	private Villager target;
    public float bowReload;
    private float nextBowFire;

    void Start() {
        base.Start();
    }

    public override string getName() {
        return "Enemy";
    }

    void Update() {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        target = getNearestVillager();
        nextBowFire -= Time.deltaTime;
        if (item == Item.SWORD) {
            if (target != null) {
                if (Vector3.Distance(transform.position, target.transform.position) < 2f) {
                    
                    if (nextBowFire <= 0) {
                        nextBowFire = bowReload;
                        target.addHealth(-attack);
                        //Random
                        
                        source.clip = attackClip[Random.Range(0, attackClip.Length)];

                        source.Play();
                        nav.SetDestination(transform.position);
                    }
                }
                else {
                    nav.SetDestination(target.transform.position);
                }
            }
        }
        else if (item == Item.BOW) {
            if (target != null) {
                if (Vector3.Distance(transform.position, target.transform.position) < 7f) {
                    nav.SetDestination(transform.position);

                    if (nextBowFire <= 0) {
                        nextBowFire = bowReload;
                        target.addHealth(-attack);
                        source.clip = attackClip[Random.Range(0, attackClip.Length)];
                        source.Play();
                    }
                }

                if (target != null) {
                    if (Vector3.Distance(transform.position, target.transform.position) < 1.2f) {
                        target.addHealth(-attack);
                        source.Play();
                        nav.SetDestination(transform.position);
                    }
                    else {
                        nav.SetDestination(target.transform.position);
                    }
                }
            }
        }
    }
	
	private Villager getNearestVillager(){
		Villager[] villagers = Transform.FindObjectsOfType<Villager>();
		
		Villager closest = null;
		float distance = float.MaxValue;
		
		foreach (Villager villager in villagers){
			float dist = Vector3.Distance(villager.transform.position, transform.position);
			if (dist < distance){
				closest = villager;
				distance = dist;
			}
		}
		
		return closest;
	}
}