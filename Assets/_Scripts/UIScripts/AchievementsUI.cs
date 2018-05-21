using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsUI : MonoBehaviour {

	[Tooltip("Le panel associé a ce menu.")]
	public GameObject achievementsPanel;
	public GameObject completedEntriesScrollView;
	public GameObject uncompletedEntriesScrollView;
	public Text achievementGlobalScoreTxt;
	public GameObject openPanelButton;

	[HideInInspector]
	public bool panelIsOpen;

	PlayerClickToMove playerMoveScript; //référencement pour arrêter le déplacement.
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
		ModuleUIManager.instance.achievementsUI = this;
		ModuleUIManager.instance.allCanvases.Add (GetComponent<Canvas> ());

	}

	#endregion

	#region ouverture et fermeture du menu

	public void OpenInGameAchievementsPanel()
	{
		openPanelButton.SetActive (false);
		ModuleUIManager.instance.inGameOptions.openPanelButton.SetActive (false);
		ModuleUIManager.instance.helpUI.openPanelButton.SetActive (false);
		ModuleUIManager.instance.playerResourcesUI.ToggleResourcesUI ();

		achievementsPanel.SetActive(true);
		playerMoveScript.enabled = false;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );
	}

	public void CloseInGameAchievementsPanel()
	{
		openPanelButton.SetActive (true);
		ModuleUIManager.instance.inGameOptions.openPanelButton.SetActive (true);
		ModuleUIManager.instance.helpUI.openPanelButton.SetActive (true);
		ModuleUIManager.instance.playerResourcesUI.ToggleResourcesUI ();

		achievementsPanel.SetActive(false);
		playerMoveScript.enabled = true;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd );

	}
	#endregion
}
