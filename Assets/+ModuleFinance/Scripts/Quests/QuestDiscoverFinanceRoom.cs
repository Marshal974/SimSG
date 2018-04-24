using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas;
using NodeCanvas.DialogueTrees;
using cakeslice;

public class QuestDiscoverFinanceRoom : MonoBehaviour 
{

	//Cette quête permet de lancer des explications sur des éléments de la pièce (le tel / la bibliotheque / l'ordi.)
	//Elle nous est encore une fois présenter par la secrétaire.

	public Camera financeRoomCam;
	public Outline phoneOutliner;
	public Outline libraryOutliner;
	public Outline computerOutliner;



	public DialogueTreeController dialogueTreeController;

	void Start()
	{
		HideAllObjectsOutliner ();
	}

	//Référencer dans le quest manager. 
	public void StartFinanceRoomQuest()
	{
		financeRoomCam.enabled = true;
		dialogueTreeController.enabled = true;
		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = false;
	}

	public void EndFinanceRoomQuest()
	{
		financeRoomCam.enabled = false;
		dialogueTreeController.enabled = false;
		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().enabled = true;
		NPCManager.instance.secretaryNPC.GetComponent<NPCMovementBehaviour> ().StartPatroling (25);
		NPCManager.instance.secretaryNPC.GetComponent<NPCGeneralBehaviour> ().outliner.enabled = false;
		QuestsManager.instance.questTrail.transform.parent = null;
		HideAllObjectsOutliner ();

	}

	public void HideAllObjectsOutliner()
	{
		computerOutliner.enabled = false;
		libraryOutliner.enabled = false;
		phoneOutliner.enabled = false;

	}

	public void ShowComputerInRoom()
	{
		HideAllObjectsOutliner ();
		computerOutliner.enabled = true;
	}

	public void ShowLibraryInRoom()
	{
		HideAllObjectsOutliner ();
		libraryOutliner.enabled = true;

	}

	public void ShowPhoneInRoom()
	{
		HideAllObjectsOutliner ();
		phoneOutliner.enabled = true;

	}
}
