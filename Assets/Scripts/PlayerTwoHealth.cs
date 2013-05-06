using UnityEngine;
using System.Collections;

public class PlayerTwoHealth : MonoBehaviour {
	
	public float maxHealth	= 10.0f;
	public float health		= 10.0f;
	bool dead				= false;
	bool invincible			= false;
	
	void Start () {
		health = maxHealth;
	}
	
	public void TakeDamage(float damage)
	{
		if (!dead && !invincible)
		{
			health -= damage;
			if (health <= 0)
			{
				EndGame();
			}
		}
		else if (dead)
		{
			health = 0.0f;
			print ("Target is already dead");
		}	
		else if (invincible)
		{
			print ("Target is invincible!");
		}	
	}
	
	void EndGame()
	{
		Main.winningPlayer = 0;
		Application.LoadLevel("GameOver");
	}
	
}
