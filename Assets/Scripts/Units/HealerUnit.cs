using UnityEngine;
using System.Collections;

public class HealerUnit : Unit 
{
	/*
	Healer(Healer):
	Damage:	1
	Health:		4
	Attack type:	Melee
	Energy Cost:	6
	Special:	Heals units for 1
	*/
	
	private static float last_time;
	
	void Start () 
	{
		damage = 1;
		health = maxHealth = 4;
	}
	
	public override void UnitUpdate()
	{
		if (last_time -1 < Time.time) {
			
			// Heal nearest friendly unit if within range
			Unit heal_unit = null;
			float dist = 1000;
			float temp_dist = 1000;
			
			foreach (GameObject temp_gameobject in ((ArrayList)Main.UnitArrays[team,lane])) {
				Unit temp_unit = (Unit)temp_gameobject.GetComponent("Unit");
				if ((team == 0 && temp_unit.transform.position.x < transform.position.x) || (team == 1 && temp_unit.transform.position.x > transform.position.x))
					continue;
				
				temp_dist = Vector3.Distance(transform.position, temp_unit.transform.position);
				if (temp_dist < dist) {
					heal_unit = temp_unit;
					dist = temp_dist;
				}
			}	
			
			if (temp_dist < 10 && heal_unit.health < heal_unit.maxHealth) {
					heal_unit.health++;
			}
			
			last_time = Time.time;
		}
	}
}
