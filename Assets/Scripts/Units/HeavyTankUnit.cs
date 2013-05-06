using UnityEngine;
using System.Collections;

public class HeavyTankUnit : Unit 
{
	
	void Start () 
	{
		damage = 4;
		health = maxHealth = 10;
	}
	
	public override void TakeDamage(int dmg, Unit attacker)
	{	
		attacker.TakeDamage(2, this);
		health -= dmg;
		if (health <= 0)
		{
			((ArrayList)Main.UnitArrays[team, lane]).Remove(self);
			Destroy (gameObject);
		}
	}
}
