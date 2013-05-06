using UnityEngine;
using System.Collections;

public class RadialControl : MonoBehaviour 
{
	
	public GameObject currentSelectedRadialPiece;
	public GameObject previousSelectedRadialPiece;
	
	public GameObject[] AvailableRadialPieces;
	
	public Material[]	mats;
	
	
	public int index = 0;
	
	// Use this for initialization
	void Start () 
	{
		currentSelectedRadialPiece.transform.localScale = new Vector3(0.7F, 0.5F, 0.7F);
	}
	
	public void AssignRadialUnit(int piece, int num)
	{
		((GameObject)AvailableRadialPieces[piece]).renderer.material = mats[num];
	}
	
	public int GetIndex()
	{
		return index;	
	}
	
	public void HideRadial()
	{
		for (int i = 0; i < AvailableRadialPieces.Length; i++)
		{
			((MeshRenderer)AvailableRadialPieces[i].GetComponent("MeshRenderer")).enabled = false;
		}
	}
	
	public void ShowRadial()
	{
		for (int i = 0; i < AvailableRadialPieces.Length; i++)
		{
			((MeshRenderer)AvailableRadialPieces[i].GetComponent("MeshRenderer")).enabled = true;
		}
	}
	public void MoveRadial(Vector3 position)
	{
		transform.position = position;
	}
	
	public void RadialGoToSelectionLeft()
	{
		index --;
		if (index == -1)
			index = 4;
		
		previousSelectedRadialPiece	=	currentSelectedRadialPiece;
		currentSelectedRadialPiece	=	AvailableRadialPieces[index];
		
		currentSelectedRadialPiece.transform.localScale = new Vector3(0.7F, 0.5F, 0.7F);
		previousSelectedRadialPiece.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
	}
	public void RadialGotoSelectionRight()
	{
		index ++;
		if (index == 5)
			index = 0;
		
		previousSelectedRadialPiece	=	currentSelectedRadialPiece;
		currentSelectedRadialPiece	=	AvailableRadialPieces[index];
		
		currentSelectedRadialPiece.transform.localScale = new Vector3(0.7F, 0.5F, 0.7F);
		previousSelectedRadialPiece.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
	}
}
