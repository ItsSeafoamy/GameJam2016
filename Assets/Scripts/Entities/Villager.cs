using UnityEngine;
using System.Collections;

public class Villager : Human {
			
	private Resource collecting;
	
	public void Update(){
		if (hasHarvestTool()){
			if (collecting != null){
				if (Vector3.Distance(transform.position, collecting.transform.position) < 2f){
					collecting.beingHarvested = true;
				} else {
					GetComponent<NavMeshAgent>().SetDestination(collecting.transform.position);
					collecting.beingHarvested = false;
				}
			} else {
				collecting = getNearestResource();
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
}