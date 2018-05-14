using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralBehaviour : MonoBehaviour {

	//Contient des infos et états clé pour le joueur.

	public Camera myCam;
	[HideInInspector]public Vector3 myStartPos;


	void Start()
	{
		myStartPos = transform.position;
	}
	public void ToggleMyCam(bool camState)
	{
		myCam.enabled = camState;
	}
}
