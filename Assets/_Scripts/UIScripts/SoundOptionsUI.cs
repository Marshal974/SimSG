using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOptionsUI : MonoBehaviour {

	//A mettre sur un bouton pour qu'il est acces a la fonction permettant d'appeler le SoundManager;
	//Comme son papa (le soundoptionsmanager) ce script est particulier.
	//seul celui ci est vraiment utile et doit être toucher. 

	bool soundPanelOpen; //un peu redondant, mais ca peut aider !

	#region les fonctions a appeler par bouton
	public void ToggleSoundOptionsPanel()
	{
		if (SoundOptionsManager.instance.soundOptionsPanelOpen) 
		{
			CloseSoundOptionsPanel ();
		} else 
		{
			OpenSoundOptionsPanel ();
		}
	}

	public void OpenSoundOptionsPanel()
	{
		soundPanelOpen = true;
		SoundOptionsManager.instance.ShowSoundOptionsPanel ();
	}
	public void CloseSoundOptionsPanel()
	{
		soundPanelOpen = false;
		SoundOptionsManager.instance.HideSoundOptionsPanel ();
	}
	#endregion
}
