﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUI : MonoBehaviour 
{
	public GameObject computerPanel;
	public GameObject allMessagesPanel;
	public GameObject currentMessagePanel;

	public Text mainSender;
	public Text mainObject;
	public Text mainContent;

	AudioSource audioS;
	PlayerClickToMove playerMoveScript;


	void Start()
	{
		//On initialise
		audioS = GetComponent<AudioSource> ();
		playerMoveScript = InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ();
		//On s'enregistre comme d'ab
		ModuleUIManager.instance.computerUI = this;
		ModuleUIManager.instance.allCanvases.Add (GetComponent<Canvas> ());

	}

	public void ShowMessage(string sender, string objectmess, string content)
	{
		currentMessagePanel.SetActive (true);

		mainSender.text = sender;
		mainObject.text = objectmess;
		mainContent.text = content;
	}

	#region ouverture et fermeture du menu

	public void OpenComputerPanel()
	{
		currentMessagePanel.SetActive (false);
		ModuleUIManager.instance.playerResourcesUI.ToggleResourcesUI (false);
		ModuleUIManager.instance.inGameOptions.openPanelButton.SetActive (false);
		computerPanel.SetActive(true);
		playerMoveScript.enabled = false;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );
	}

	public void CloseComputerPanel()
	{
		ModuleUIManager.instance.playerResourcesUI.ToggleResourcesUI (true);
		ModuleUIManager.instance.inGameOptions.openPanelButton.SetActive (true);
		computerPanel.SetActive(false);
		playerMoveScript.enabled = true;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );

	}

	#endregion
}
