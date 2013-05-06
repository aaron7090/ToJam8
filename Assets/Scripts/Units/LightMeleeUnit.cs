using UnityEngine;
using System.Collections;

public class LightMeleeUnit : Unit 
{
	
	private bool blockFirstAttack = true;
	
	void Start () 
	{
		damage = 2;
		health = maxHealth = 3;
	}
	public override void TakeDamage(int dmg, Unit attacker)
	{
		if (blockFirstAttack)
		{
			Debug.Log ("BLOCKED");
			blockFirstAttack = false;
		}
		else
		{
			health -= dmg;
			
			if (health <= 0)
			{
				((ArrayList)Main.UnitArrays[team, lane]).Remove(self);
				Destroy (gameObject);
			}
		}
	}
}
