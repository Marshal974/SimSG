﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class InGameOptions : MonoBehaviour 

{
	[Tooltip("Le panel associé a ce menu.")]
	public GameObject optionsPanel;

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
		ModuleUIManager.instance.inGameOptions = this;
		ModuleUIManager.instance.allCanvases.Add (GetComponent<Canvas> ());
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (panelIsOpen) 
			{
				CloseInGameOptionsPanel ();
			} else 
			{
				OpenInGameOptionsPanel ();
			}
			panelIsOpen = !panelIsOpen;
		}
	}

	#endregion

	#region fontions spécifiques a ce menu

	public void BackToMainMenu()
	{
		SoundOptionsManager.instance.HideSoundOptionsPanel ();
		SceneManager.LoadScene (0, LoadSceneMode.Single);

	}
	public void QuitTheGame()
	{
		Application.Quit ();
	}
	#endregion

	#region ouverture et fermeture du menu
	public void OpenInGameOptionsPanel()
	{
		playerMoveScript.enabled = false;
		openPanelButton.SetActive (false);
		ModuleUIManager.instance.helpUI.openPanelButton.SetActive (false);
		ModuleUIManager.instance.achievementsUI.openPanelButton.SetActive (false);

		optionsPanel.SetActive(true);
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );

	}

	public void CloseInGameOptionsPanel()
	{
		openPanelButton.SetActive (true);
		ModuleUIManager.instance.helpUI.openPanelButton.SetActive (true);
		ModuleUIManager.instance.achievementsUI.openPanelButton.SetActive (true);

		optionsPanel.SetActive(false);
		playerMoveScript.enabled = true;
		SoundOptionsManager.instance.HideSoundOptionsPanel ();
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );

	}
	#endregion
}
