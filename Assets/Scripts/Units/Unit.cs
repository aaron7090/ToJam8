using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour 
{
	public int team;
	public int lane;
	public int type;
	
	public GameObject target;
	
	// stats vary for each unit type 
	public static float meleeAttackRange = 1.0f;
	public static float rangeAttackRange = 4.0f;
	
	public float attackRange = meleeAttackRange;
	public int health;
	public int maxHealth;
	public int damage;
	
	public string unittype;
	// mostly never changing
	public float movespeed  = 1.5f;
	
	public GameObject self;
	
	public void UnitSpawned() 
	{
		
		foreach (GameObject temp_unit_gameobject in ((ArrayList)Main.UnitArrays[team,lane]))
		{
			Unit temp_unit = (Unit)temp_unit_gameobject.GetComponent("Unit");
			if (temp_unit.type == 9)
				damage++;
		}
	}
	
	void Update () 
	{
		switch (team) {
			case 0:
				if (transform.position.x >= GameObject.Find("SpawnRightMid").transform.position.x) {
					Destroy(gameObject);
					((PlayerTwoHealth)GameObject.Find("Main Camera").GetComponent("PlayerTwoHealth")).TakeDamage(1);
				}
				break;
			case 1:
				if (transform.position.x <= GameObject.Find("SpawnLeftMid").transform.position.x) {
				Debug.Log("TEAM: "+team);
					Destroy(gameObject);
					((PlayerOneHealth)GameObject.Find("Main Camera").GetComponent("PlayerOneHealth")).TakeDamage(1);
				}
				break;
		}
		if (target == null)
		{
			rigidbody.constraints	=	RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
			
			switch (team) 
			{
				case 0:
					// Move to the right
					rigidbody.velocity = new Vector3(movespeed,0f,0f);
					break;
				case 1: 
					// Move to the left
					rigidbody.velocity = new Vector3(-movespeed,0f,0f);
					break;
			}
			
			if ((ArrayList)Main.UnitArrays[GetEnemyTeam(),lane] != null && ((ArrayList)Main.UnitArrays[GetEnemyTeam(),lane]).Count > 0)
			{
				for (int i = 0; i < ((ArrayList)Main.UnitArrays[GetEnemyTeam(),lane]).Count; i++)
				{
					GameObject enemy = (GameObject)((ArrayList)Main.UnitArrays[GetEnemyTeam(),lane])[i];
					
					
					var dist = Vector3.Distance(enemy.transform.position, this.transform.position);
					
					if (dist < attackRange)
					{
						target = enemy;
						rigidbody.constraints = RigidbodyConstraints.FreezeAll;
					}
				}
			}
			UnitMoved();
		}
		else
		{
			if (((tk2dAnimatedSprite)gameObject.GetComponent("tk2dAnimatedSprite")).IsPlaying(unittype+"Move"))
			{
				((tk2dAnimatedSprite)gameObject.GetComponent("tk2dAnimatedSprite")).Play(unittype+"Attack");
				((tk2dAnimatedSprite)gameObject.GetComponent("tk2dAnimatedSprite")).animationEventDelegate += attackComplete;	
			}
		}
		UnitUpdate();
	}
	public virtual void attackComplete(tk2dAnimatedSprite 	sprite, tk2dSpriteAnimationClip 	clip, tk2dSpriteAnimationFrame 	frame, int 	frameNum)			
	{
		if (target == null)
			return;
		((tk2dAnimatedSprite)gameObject.GetComponent("tk2dAnimatedSprite")).Play(unittype+"Move");
		UnitAttack();
		if (((Unit)target.GetComponent("Unit")).health <= 0)
		{
			((tk2dAnimatedSprite)gameObject.GetComponent("tk2dAnimatedSprite")).animationEventDelegate -= attackComplete;
			target = null;
		}
	}
	
	public virtual void UnitAttack()
	{
		// override for specific unit attacks & animation
		((Unit)target.GetComponent("Unit")).TakeDamage(damage, this);
	}
	public virtual void UnitMoved()
	{
	}
	public virtual void UnitUpdate()
	{
	}
	public virtual void TakeDamage(int dmg, Unit attacker)
	{
		health -= dmg;
	   
		if (health <= 0)
		{
			Debug.Log ("c: "+((ArrayList)Main.UnitArrays[team, lane]).Count);
		 	((ArrayList)Main.UnitArrays[team, lane]).Remove(self);
			Debug.Log ("cafter: "+((ArrayList)Main.UnitArrays[team, lane]).Count);
			Destroy (gameObject);
		}
	}
	// Changes the unit from a melee unit to a ranged unit
	public void setAsRangedUnit() {
		attackRange = rangeAttackRange;
	}

	// Changes the unit from a melee unit to a ranged unit and accepts an attack range multiplier
	public void setAsRangedUnit(float multiplier) {
		attackRange = rangeAttackRange * multiplier;
	}
	
	
	public int GetEnemyTeam()
	{
		if (team == 0)
			return  1;
		else
			return  0;
	}
}
