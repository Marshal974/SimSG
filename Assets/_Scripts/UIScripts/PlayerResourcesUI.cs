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

	//J'ai mis en commentaire le code lié a l'affichage du score de climat social et de l'ancien slider. Je laisse le code au cas ou on change la présentation encore ou qu'on veut afficher un score textuel etc.

	public GameObject ResourcesPanel; //Le panel contenant tous les UI de ressources
//	public Slider socialClimateSlider;
	public Slider playerProgressSlider;
	public Text playerGoldDisplay; 
//	public Text SocialClimateDisplay;
	public Text currentMonthDisplay;
	public Text patientsCountDisplay;
	public Text agentsCountDisplay;
	public RectTransform socialClimatePointer;

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
		//Ancienne méthode.
//		socialClimateSlider.value = newClimate;
//		SocialClimateDisplay.text = newClimate.ToString ();

		//Changer la direction du pointeur.
		//50 = neutre, 0 doit faire 90 degrés, et 100 doit faire -90 degrès
		//donc c'est x = value -50.if >0 : x+=40, if <0 x-=40, si ==0 alors rien.
		int tmpClimate;

		if (newClimate > 50) 
		{
			tmpClimate = newClimate * 90 / 100;

		} else if (newClimate == 50) 
		{
			tmpClimate = 0;
		} else 
		{
			tmpClimate = newClimate - 100;
			tmpClimate = tmpClimate * 90 / 100;
		}

//		tmpClimate = newClimate - 50;
//		Debug.Log (tmpClimate);
//
//		if (tmpClimate > 0) 
//		{
//			tmpClimate  += tmpClimate *50/90;
//
////			tmpClimate += 40;
//		} 
//		else if (tmpClimate == 0) 
//		{
//			//rien.
//		} 
//		else 
//		{
//			tmpClimate  -= tmpClimate *50/90;
//
////			tmpClimate -= 40;	
//		}
//
		//on actu le visuel et voila:
		socialClimatePointer.localRotation = Quaternion.Euler (0, 180, tmpClimate);

	}

	public void UpdatePlayerProgress(int pProgress)
	{
		playerProgressSlider.value = pProgress;
	}

}
