using UnityEngine;
using System.Collections;

public class HeavyBruiserUnit : Unit {
	
	/*
	Heavy Bruiser Unit(Berserker):
	Damage:	6
	Health:		8
	Attack type:	Melee
	Energy Cost:	12
	Special:           Cleaves to second target for 3 damage
	*/

	void Start () {
		damage = 6;
		health = maxHealth = 8;
	}
	
	public override void UnitAttack() {
		
		((Unit)target.GetComponent("Unit")).TakeDamage(damage, this);
		
		// Cleave to second nearest enemy unit if within range
		
		Unit cleave_unit = null;
		float temp_dist;
		float dist = 1000;
		
		
		 
		foreach (GameObject temp_gameobject in ((ArrayList)Main.UnitArrays[GetEnemyTeam(),lane])) {
				Unit temp_unit = (Unit)temp_gameobject.GetComponent("Unit");
			temp_dist = Vector3.Distance(((Unit)target.GetComponent("Unit")).transform.position, temp_unit.transform.position);
			if (temp_dist < dist) {
				cleave_unit = temp_unit;
				dist = temp_dist;
			}
		}
		if (cleave_unit != null && dist < 15 && (cleave_unit.gameObject != target))
			cleave_unit.TakeDamage(3, this);
	}
}
