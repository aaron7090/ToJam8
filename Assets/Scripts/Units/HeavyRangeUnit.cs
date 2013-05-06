using UnityEngine;
using System.Collections;

public class HeavyRangeUnit : Unit {
	
	/*
	Heavy Range Unit(Artillery):
	Damage:	6
	Health:		5
	Attack type:	Range
	Energy Cost:   8
	Special:	Increases attacks for units in the same lane by 1
	*/
	
	void Start () {
		
		damage = 6;
		health = maxHealth = 5;
		setAsRangedUnit();
		
		foreach (GameObject temp_gameobject in ((ArrayList)Main.UnitArrays[team,lane])) {
				Unit temp_unit = (Unit)temp_gameobject.GetComponent("Unit");
			temp_unit.damage++;
		}
	}
	
	public override void TakeDamage(int dmg, Unit attacker)
	{
		health -= dmg;
		
		if (health <= 0) {
			foreach (GameObject temp_gameobject in ((ArrayList)Main.UnitArrays[team,lane])) {
				Unit temp_unit = (Unit)temp_gameobject.GetComponent("Unit");
				temp_unit.damage--;
			}
			((ArrayList)Main.UnitArrays[team, lane]).Remove(self);
			Destroy (gameObject);
		}
	}
}
