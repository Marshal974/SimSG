using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour {


	public static InGameManager instance;

	public GameObject playerObj; // référencement du gameobject joueur.
	public MainCameraController camController; //référencement du controller pour pouvoir désactiver le script quand on en a pas besoin.


	#region MonoB functions

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("Two Managers here");
			Destroy (gameObject);
		}
	}
	#endregion
}
