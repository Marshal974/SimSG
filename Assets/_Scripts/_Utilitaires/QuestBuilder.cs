using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class QuestBuilder : MonoBehaviour 
{
	//ce script est au coeur du système de création de quête
	//Il a pour mission de référencer en un endroit de façon simple et accessible
	//Toutes les fonctionnalités recquises a la création d'une nouvelle quête.

	//Il arrive que des quêtes spécifique dérive de ce script.
	//Il contient les fonctions récurrentes entre les quêtes.
	//On peut trouver aussi certaines de ces fonctions sur le QuestManager pour référencement.


	public DialogueTreeController dialogueTree; //chaque quête a un dialogue tree associé.

	public Camera specificCam; //Une caméra spécial qui mettra en valeur le deuxieme protagoniste du dialogue/ pas obligé de compléter.

	#region fonctions utiles pour construire une quête

	public void StartDialogueQuest()
	{
		dialogueTree.enabled = true;
		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = false;
	}

	public void EndDialogueQuest()
	{
		dialogueTree.enabled = false;
		QuestsManager.instance.EndCurrentQuest ();
		DisableAllQuestCams ();
		Invoke ("DelayedEndOfQuestEvents", .5f);

	}

	public void ShowSpecificCam()
	{
		if (specificCam) 
		{
			specificCam.enabled = true;
		}
		InGameManager.instance.playerObj.GetComponent<PlayerGeneralBehaviour> ().ToggleMyCam (false);

	}

	public void ShowPlayerCam()
	{
		if (specificCam) 
		{
			specificCam.enabled = false;
		}
		InGameManager.instance.playerObj.GetComponent<PlayerGeneralBehaviour> ().ToggleMyCam (true);

	}
		
	public void ChangePlayerCredits(int bonusCredits)
	{
		ResourcesManager.instance.playerGold += bonusCredits;
		if (bonusCredits > 0) {
			GetComponent<AudioSource> ().PlayOneShot (SoundsManager.instance.soundsSO.successSnd);

			AlertMessageManager.instance.CreateAnAlert ("Vous avez fait gagné " + bonusCredits + " million(s) à l'hopital.",1);
		} else {
			GetComponent<AudioSource> ().PlayOneShot (SoundsManager.instance.soundsSO.errorSnd);
			AlertMessageManager.instance.CreateAnAlert ("Vous avez fait perdre " + -bonusCredits + " million(s) à l'hopital.",3);

		}
	}

	public void ChangeSocialClimate(int climateChange)
	{
		ResourcesManager.instance.socialClimate += climateChange;
	}

	public void ShowQuestAgentTrail(Transform destination)
	{
		StartCoroutine (MoveTrailAgentToDest(destination.position));
	}
		
	public void ChangeTheMonth(int month)
	{
		ResourcesManager.instance.currentMonth = (AllEnum.Months)month;
	}

	public void DisplayAnImage(Sprite toShow)
	{
		ModuleUIManager.instance.dialogueUI.graphDisplayer.enabled = true;
		ModuleUIManager.instance.dialogueUI.graphDisplayer.sprite = toShow;
		ModuleUIManager.instance.dialogueUI.graphDisplayer.SetNativeSize();
	}

	public void HideDisplayedImage()
	{
		ModuleUIManager.instance.dialogueUI.graphDisplayer.enabled = false;

	}

	public void ChangePlayerProgressInModule(int bonusInPrct)
	{
		ResourcesManager.instance.playerProgress += bonusInPrct;
	}

	public void ShowLoadingScreen()
	{
		LoadingScreenManager.instance.ShowLoadingScreen ();
	}

	#endregion

	#region utilitaires
	//pour le flow du gameplay, fait pas gaffe
	void DelayedEndOfQuestEvents()
	{
		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = true;

	}

	void DisableAllQuestCams()
	{
		if (specificCam) 
		{
			specificCam.enabled = false;
		}
		InGameManager.instance.playerObj.GetComponent<PlayerGeneralBehaviour> ().ToggleMyCam (false);

	}

	IEnumerator MoveTrailAgentToDest(Vector3 destPos)
	{
		QuestsManager.instance.trailAgent.enabled = false;
		QuestsManager.instance.trailAgent.transform.position = InGameManager.instance.playerObj.transform.position;
		yield return new WaitForEndOfFrame ();
		QuestsManager.instance.trailAgent.enabled = true;
		QuestsManager.instance.trailAgent.SetDestination (destPos);
	}

	#endregion

}
