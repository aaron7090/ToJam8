using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int team;
	public int[] units = new int[5];
	
	void Start () {
		
	}
	
	public void AssignPlayerUnits () {
		//team = Selection.team;
		//units = Selection.units;
		
		for (int i = 0; i < 5; i++) {
			units[i] = Random.Range(0,9);
		}
	}
}
