﻿using UnityEngine;
using System.Collections;
using System;

public class Enemy : Human {

	private Villager target;
    public float bowReload;
    private float nextBowFire;

    public override string getName() {
        return "Enemy";
    }

    void Update() {
        NavMeshAgent nav = GetComponent<NavMeshAgent>();
        target = getNearestVillager();

        if (item == Item.SWORD) {
            if (target != null) {
                if (Vector3.Distance(transform.position, target.transform.position) < 2f) {
                    target.addHealth(-attack * Time.deltaTime);
                    nav.SetDestination(transform.position);
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

                    nextBowFire -= Time.deltaTime;

                    if (nextBowFire <= 0) {
                        nextBowFire = bowReload;

                        target.addHealth(-attack);
                    }
                }

                if (target != null) {
                    if (Vector3.Distance(transform.position, target.transform.position) < 1.2f) {
                        target.addHealth(-attack * Time.deltaTime);
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