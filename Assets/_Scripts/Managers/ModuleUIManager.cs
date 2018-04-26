using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleUIManager : MonoBehaviour 
{

	//Gère et référence toutes les interfaces et leurs scripts associés spécifique a la scène en cours.

	public static ModuleUIManager instance;
	[Header("Les canvas concernés viennent s'enregistrer ci dessous tout seul:")]
	public InGameOptions inGameOptions;//Script situé sur le IngameoptionsCanvas : le script s'enregistre ici tout seul, pareil plus bas.
	public HelpUI helpUI;
	public PlayerResourcesUI playerResourcesUI;
	public WelcomeInModuleUI welcomeInModuleUI;

	public List<Canvas> allCanvases = new List<Canvas>();
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("2 moduleUIManager");
			Destroy (gameObject);
		}
	}

	public void HideAllUI()
	{
		foreach (var c in allCanvases) {
			c.enabled = false;
		}
	}

	public void ShowAllUI()
	{
		foreach (var c in allCanvases) {
			c.enabled = true;
		}
	}
}
