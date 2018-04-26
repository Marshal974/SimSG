using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResourcesUI : MonoBehaviour 
{
	//Ce script commence par se référencer chez le UI Manager;
	//il gère toutes les affichage de ressource du joueur;
	//Les ressources sont calculés par le ResourcesManager et
	//L'ordre d'actualisation de UI est également envoyer par ce dernier.

	public GameObject ResourcesPanel; //Le panel contenant tous les UI de ressources
	public Text playerGoldDisplay; 
	public Slider socialClimateSlider;
	public Text SocialClimateDisplay;
	public Text currentMonthDisplay;
	public Text patientsCountDisplay;
	public Text agentsCountDisplay;

	void Start () 
	{
		//On s'enregistre auprès du moduleUIManager
		ModuleUIManager.instance.playerResourcesUI = this;
		ModuleUIManager.instance.allCanvases.Add (GetComponent<Canvas> ());

	}

	//A appelé pour cacher/afficher les ressources du joueur.
	public void ToggleResourcesUI()
	{
		ResourcesPanel.SetActive (!ResourcesPanel.activeSelf);
	}
	public void ToggleResourcesUI( bool visible)
	{
		ResourcesPanel.SetActive (visible);
	}
	//mettre a jour l'affichage du climat social dans le UI:
	public void UpdateSocialClimateUI(int newClimate)
	{
		socialClimateSlider.value = newClimate;
		SocialClimateDisplay.text = newClimate.ToString ();
	}

}
