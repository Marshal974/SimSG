using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;
using UnityEngine.Events;

public class QuestBuilder : MonoBehaviour 
{

	//Ce quest builder est a associé a un autre script qui commence par Quest.
	//Il contient les fonctions récurrentes entre les quêtes.
	//On peut trouver aussi certaines de ces fonctions sur le QuestManager pour diverses raisons.


	public DialogueTreeController dialogueTree; //chaque quête a un dialogue tree associé.

	public Camera specificCam; //Une caméra spécial qui mettra en valeur le deuxieme protagoniste du dialogue/ pas obligé de compléter.

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

	void DisableAllQuestCams()
	{
		if (specificCam) 
		{
			specificCam.enabled = false;
		}
		InGameManager.instance.playerObj.GetComponent<PlayerGeneralBehaviour> ().ToggleMyCam (false);

	}

	void DelayedEndOfQuestEvents()
	{
		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = true;

	}
}
