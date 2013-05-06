using UnityEngine;
using System.Collections;

public class MediumRangeUnit : Unit {
	
	/*
	Medium Range Unit(Ranger):
	Damage:	2
	Health:		4
	Attack type:	Range
	Energy Cost:	6
	Special:	Double attack range
	*/
	
	void Start () {
		damage = 2;
		health = maxHealth = 4;
		setAsRangedUnit (2);
	}
	
	
}
