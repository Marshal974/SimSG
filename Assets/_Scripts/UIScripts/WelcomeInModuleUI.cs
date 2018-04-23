using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(AudioSource))]

public class WelcomeInModuleUI : MonoBehaviour 
{

	//Gère l'écran d'accueil de quand on arrive dans un module.
	//Il affiche les explications de base sur : 
	//les fonctionnalités, l'interface
	//qui on incarne, ce qu'on doit faire.

	//ce array contient tous les panel a afficher sur l'écran d'accueil
	//Les panel sont afficher dans l'ordre.
	//Ne pas changer ce que ya déja de base dans l'array, rajouter a la fin de la liste les panels spécifique au scénario!
	[Tooltip("Faire glisser ici tous les panels en enfant.")]public GameObject[] allPanelsToShowInOrder;

	int currentPanelIndex;
	Canvas canvas;
	AudioSource audioS;

	void Start () 
	{
		//On config qq variables.
		canvas = GetComponent<Canvas> ();
		audioS = GetComponent<AudioSource> ();

		//On s'enregistre auprès du moduleUIManager
		ModuleUIManager.instance.welcomeInModuleUI = this;
	}

	//Appelé par le bouton en enfant : ShowNextBtn
	public void ShowNextPanel()
	{
		if (currentPanelIndex < allPanelsToShowInOrder.Length-1) 
		{
			//on montre le pannel ressource et on l'explique
			if (currentPanelIndex == 0) 
			{
				ModuleUIManager.instance.playerResourcesUI.transform.GetComponent<Canvas> ().sortingOrder++;
			}
			//On montre le bouton aide et on explique
			if (currentPanelIndex == 1) 
			{
				ModuleUIManager.instance.playerResourcesUI.GetComponent<Canvas> ().sortingOrder--;
				ModuleUIManager.instance.helpUI.GetComponent<Canvas> ().sortingOrder++;

			}
			//on donne la quête, on atteind le state spécifique au module ou ya pu de délire spéciaux comme ca.
			if (currentPanelIndex == 2) 
			{
				ModuleUIManager.instance.helpUI.GetComponent<Canvas> ().sortingOrder--;

			}
			//Et dans tous les cas donc(pour les trucs spécifiques au module) faire ca:
			allPanelsToShowInOrder [currentPanelIndex].SetActive (false);
			allPanelsToShowInOrder [currentPanelIndex + 1].SetActive (true);
			audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd);
			currentPanelIndex++;
		} else 
		{
			EndWelcomePanelEvent ();
		}
	}


	/// <summary>
	/// A appelé pour lancer le process d'affichage de l'ui lié a l'event de bienvenue dans le module
	/// </summary>
	public void StartWelcomePanelEvent()
	{
		TimelineManager.instance.PlayWelcomeCutscene(1);

		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = false;
		canvas.enabled = true;

		currentPanelIndex = 0;
		allPanelsToShowInOrder [currentPanelIndex].SetActive (true);

		audioS.PlayOneShot (SoundsManager.instance.soundsSO.successSnd);

	}

	//a lancer lorsqu'on atteind le dernier panel
	void EndWelcomePanelEvent()
	{
		TimelineManager.instance.PlayWelcomeCutscene(2);

		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = true;

		allPanelsToShowInOrder [currentPanelIndex].SetActive (false);
		canvas.enabled = false;
	}
}
