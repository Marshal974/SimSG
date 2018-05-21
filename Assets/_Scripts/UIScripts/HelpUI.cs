﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class HelpUI : MonoBehaviour
{
	[Tooltip("Le panel associé a ce menu.")]
	public GameObject helpPanel;
	public GameObject allEntriesScrollView;
	public Text mainEntryNameTxt;
	public Text mainEntryDefinitionTxt;
	public Image mainEntryVisualImage;

	public GameObject openPanelButton;

	[HideInInspector]
	public bool panelIsOpen;

	PlayerClickToMove playerMoveScript; //référencement pour arrêter le déplacement quand on est dans un menu.
	AudioSource audioS;

	#region MonoB functions
	void Awake()
	{
		audioS = GetComponent<AudioSource> ();
	}

	void Start()
	{
		playerMoveScript = InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ();

		//On s'enregistre auprès du moduleUIManager
		ModuleUIManager.instance.helpUI = this;
		ModuleUIManager.instance.allCanvases.Add (GetComponent<Canvas> ());

	}

	#endregion

	#region fontions spécifiques a ce menu


	#endregion

	#region ouverture et fermeture du menu

	public void OpenInGameHelpPanel()
	{
		openPanelButton.SetActive (false);
		ModuleUIManager.instance.playerResourcesUI.ToggleResourcesUI ();
		ModuleUIManager.instance.inGameOptions.openPanelButton.SetActive (false);
		ModuleUIManager.instance.achievementsUI.openPanelButton.SetActive (false);

		helpPanel.SetActive(true);
		playerMoveScript.enabled = false;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );
	}

	public void CloseInGameHelpPanel()
	{
		openPanelButton.SetActive (true);
		ModuleUIManager.instance.playerResourcesUI.ToggleResourcesUI ();
		ModuleUIManager.instance.inGameOptions.openPanelButton.SetActive (true);
		ModuleUIManager.instance.achievementsUI.openPanelButton.SetActive (true);

		helpPanel.SetActive(false);
		playerMoveScript.enabled = true;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );

	}
	#endregion
}
