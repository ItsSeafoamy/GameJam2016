using UnityEngine;
using System.Collections;

public class Villager : Human {
			
	private Resource collecting;
	
	public void Update(){
		NavMeshAgent nav = GetComponent<NavMeshAgent>();
		Enemy nearestEnemy = getNearestEnemy();
		
		if (nearestEnemy != null && !hasAttackingTool()){
			if (Vector3.Distance(transform.position, nearestEnemy.transform.position) < 5f){
				Vector3 dir = transform.position - nearestEnemy.transform.position;
				dir = dir.normalized*10f;
				
				nav.SetDestination(transform.position + dir);
				
				if (collecting != null) collecting.beingHarvested = false;
				return;
			}
		} 
		
		if (hasHarvestTool()){
			if (collecting != null){
				if (Vector3.Distance(transform.position, collecting.transform.position) < 2f){
					collecting.beingHarvested = true;
					nav.SetDestination(transform.position);
				} else {
					nav.SetDestination(collecting.transform.position);
					collecting.beingHarvested = false;
				}
			} else {
				collecting = getNearestResource();
			}
		} else if (hasAttackingTool()){
			if (nearestEnemy != null){
				if (Vector3.Distance(transform.position, nearestEnemy.transform.position) < 2f){
					nearestEnemy.addHealth(-dps*Time.deltaTime);
					nav.SetDestination(transform.position);
				} else {
					nav.SetDestination(nearestEnemy.transform.position);
				}
			}
		}
	}
	
	private Resource getNearestResource(){
		Resource[] resources = Transform.FindObjectsOfType<Resource>();
		
		if (resources.Length != 0){
			Resource closest = null;
			float distance = float.MaxValue;
			
			foreach (Resource resource in resources){
				float dist = Vector3.Distance(resource.transform.position, transform.position);
				if (dist < distance && resource.getPreferredTool() == item){
					closest = resource;
					distance = dist;
				}
			}
			
			return closest;
		} else return null;
	}
	
	private Enemy getNearestEnemy(){
		Enemy[] enemies = Transform.FindObjectsOfType<Enemy>();
		
		if (enemies.Length != 0){
			Enemy closest = null;
			float distance = float.MaxValue;
			
			foreach (Enemy enemy in enemies){
				float dist = Vector3.Distance(enemy.transform.position, transform.position);
				if (dist < distance){
					closest = enemy;
					distance = dist;
				}
			}
			
			return closest;
		} else return null;
	}
}