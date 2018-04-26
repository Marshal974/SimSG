using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas;
using NodeCanvas.DialogueTrees;

[RequireComponent(typeof(DialogueTreeController))]

public class QuestFollowMe : QuestBuilder 
{

	//La quête consiste a commencer par un dialogue entre le joueur et un pnj puis le pnj se dirige a un point décidé.
	//Il y a une fonction pour lancer la quête depuis le quest manager.

	public GameObject targetToFollow; //Ici la secrétaire quoi.
	public Transform placeToGoTo; //la ou on veut aller avec le pnj.

	//Démarrer la quête et définir le pnj a suivre.
	public void StartQuestFollowMe()
	{
		StartDialogueQuest ();
		ShowSpecificCam ();
		targetToFollow.GetComponent<NPCGeneralBehaviour> ().outliner.enabled = false;

	}

	public void EndQuestFollowMe()
	{
		EndDialogueQuest ();
		targetToFollow.GetComponent<NPCGeneralBehaviour> ().outliner.enabled = true;
		GoToDestination ();
		QuestsManager.instance.questTrail.transform.parent = targetToFollow.transform;
		QuestsManager.instance.questTrail.transform.localPosition = Vector3.zero;
	}

	public void CancelQuestFollowMe()
	{
		EndQuestFollowMe ();

		//Pu utile dans ce cas : la quête est pas répétable, soit il vient soit pas (le joueur).
//		QuestsManager.instance.AddQuestActivator (targetToFollow.transform.position, AllEnum.allQuests.followMe, .5f);
	}

	void GoToDestination()
	{
		targetToFollow.GetComponent<NPCMovementBehaviour> ().GoToTarget (placeToGoTo.position);
	}

	//OBSOLETE: tout est sur le quest builder mtnt:
	//	public void ShowPlayerTalking()
	//	{
	//		InGameManager.instance.playerObj.GetComponent<PlayerGeneralBehaviour> ().ToggleMyCam (true);
	//		targetToFollow.GetComponent<NPCGeneralBehaviour> ().ToggleMyCam (false);
	//	}
	//
	//	public void ShowNPCTalking()
	//	{
	//		InGameManager.instance.playerObj.GetComponent<PlayerGeneralBehaviour> ().ToggleMyCam (false);
	//		targetToFollow.GetComponent<NPCGeneralBehaviour> ().ToggleMyCam (true);
	//	}
	//
}
