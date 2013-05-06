using UnityEngine;
using System.Collections;

public class MediumMeleeUnit : Unit 
{
	
	void Start () 
	{
		damage = 3;
		health = maxHealth = 6;
	}
	
	public override void TakeDamage(int dmg, Unit attacker)
	{	
		if (attacker.attackRange == rangeAttackRange) // 5 because it is the default attack range(melee), might have to change to boolean if melee or ranged
		{
			int adjustedDamage = dmg - 1;
			if (adjustedDamage > 0)
				health -= adjustedDamage;
		}
		else {
			health -= dmg;
			if (health <= 0)
			{
				((ArrayList)Main.UnitArrays[team, lane]).Remove(self);
				Destroy (gameObject);
			}
		}
	}
}
