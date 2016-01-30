using UnityEngine;
using System.Collections;

public class Enemy : Human {

	private Villager target;
		
	void Update(){
		NavMeshAgent nav = GetComponent<NavMeshAgent>();
		target = getNearestVillager();
		
		if (target != null){
			if (Vector3.Distance(transform.position, target.transform.position) < 2f){
				target.addHealth(-dps*Time.deltaTime);
				nav.SetDestination(transform.position);
			} else {
				nav.SetDestination(target.transform.position);
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