using UnityEngine;
using System.Collections;

public class LightRangeUnit : Unit {
	
	/*
	Light Range Unit(Shooter):
	Damage:	2
	Health:		3
	Attack type:	Range
	Energy Cost:	5
	Special:	Attacks twice
	*/
	
	void Start () {
		damage = 2;
		health = maxHealth = 3;
		setAsRangedUnit();
	}
	
	public override void UnitAttack() {
		((Unit)target.GetComponent("Unit")).TakeDamage(damage, this);
		((Unit)target.GetComponent("Unit")).TakeDamage(damage, this);
	}
}
