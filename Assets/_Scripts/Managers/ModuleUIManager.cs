using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleUIManager : MonoBehaviour 
{

	//Gère et référence toutes les interfaces et leurs scripts associés spécifique a la scène en cours.

	public static ModuleUIManager instance;

	public InGameOptions inGameOptions;//Script situé sur le IngameoptionsCanvas : le script s'enregistre ici tout seul, pareil plus bas.
	public HelpUI helpUI;
	public PlayerResourcesUI playerResourcesUI;
	public WelcomeInModuleUI welcomeInModuleUI;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("2 moduleUIManager");
			Destroy (gameObject);
		}
	}
}
