using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour {


	public static InGameManager instance;

	public GameObject playerObj; // référencement du gameobject joueur.
	public MainCameraController camController; //référencement du controller pour pouvoir désactiver le script quand on en a pas besoin.

	[Header("Configuration des paramètres principaux du jeu.")]

	[Tooltip("A cocher pour voir les messages de présentation du module")]
	public bool isShowingWelcomeInModulePanels = true;


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

	void Start()
	{
		if(isShowingWelcomeInModulePanels)
		{
			Invoke ("StartWelcomeInModuleProcedure", 1.5f);
		}
	}
	#endregion

	#region Lancement d'évênements important

	public void StartWelcomeInModuleProcedure()
	{
		ModuleUIManager.instance.welcomeInModuleUI.StartWelcomePanelEvent ();
	}

	#endregion
}
