using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
	
	public enum Type {WOOD, STONE}
	
	public Type type;
	
	public bool beingHarvested;
	private float timeTilHarvest = 5;
	
	public Human.Item getPreferredTool(){
		if (type == Type.WOOD) return Human.Item.AXE;
		else if (type == Type.STONE) return Human.Item.PICKAXE;
		else throw new System.NotSupportedException();
	}
	
	void Update(){
		if (beingHarvested){
			timeTilHarvest -= Time.deltaTime;
			
			if (timeTilHarvest <= 0){
				if (type == Type.WOOD){
					int collected = Random.Range(1, 4);
					Game.wood += collected;
					
					Debug.Log("+" + collected + " wood (Total: " + Game.wood + ")");
				} else if (type == Type.STONE){
					int collected = Random.Range(1, 4);
					Game.stone += collected;
					
					Debug.Log("+" + collected + " stone (Total: " + Game.stone + ")");
				}
				Destroy(gameObject);
			}
		}
	}
}