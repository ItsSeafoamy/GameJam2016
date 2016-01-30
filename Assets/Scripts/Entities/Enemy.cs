using UnityEngine;
using System.Collections;

public class Enemy : Human {
	
	void Update(){
		NavMeshAgent nav = GetComponent<NavMeshAgent>();
		
		nav.SetDestination(getNearestVillager().transform.position);
	}
	
	private Entity getNearestVillager(){
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