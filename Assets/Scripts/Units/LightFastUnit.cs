using UnityEngine;
using System.Collections;

public class LightFastUnit : Unit 
{
	
	void Start () 
	{
		damage = 1;
		health = maxHealth = 3;
		
		movespeed *= 2;
	}
}
