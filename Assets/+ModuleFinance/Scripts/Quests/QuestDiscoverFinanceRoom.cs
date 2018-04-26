using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas;
using NodeCanvas.DialogueTrees;
using cakeslice;

public class QuestDiscoverFinanceRoom : QuestBuilder 
{

	//Cette quête permet de lancer des explications sur des éléments de la pièce (le tel / la bibliotheque / l'ordi.)
	//Elle nous est encore une fois présenter par la secrétaire.

	public Outline phoneOutliner;
	public Outline libraryOutliner;
	public Outline computerOutliner;

	void Start()
	{
		HideAllObjectsOutliner ();
	}

	//Référencer dans le quest manager. 
	public void StartFinanceRoomQuest()
	{
		StartDialogueQuest ();
		specificCam.enabled = true;

	}

	public void EndFinanceRoomQuest()
	{
		EndDialogueQuest ();
		NPCManager.instance.secretaryNPC.GetComponent<NPCMovementBehaviour> ().StartPatroling (25);
		NPCManager.instance.secretaryNPC.GetComponent<NPCGeneralBehaviour> ().outliner.enabled = false;
		QuestsManager.instance.trailAgent.enabled = false;
		HideAllObjectsOutliner ();
		OfficeComputerManager.instance.AddNewMail ("Directeur", "Bienvenu", "\n\nBonjour, je me présente, je suis le nouveau directeur Laurent BeauChamp.\nJe suis heureux de prendre mon poste en même temps que vous.\nNous allons devoir travailler ensemble et je compte sur vous pour m'aider dans les décisions... En effet je suis récemment diplômé de la très haute école en santé publique et j'ai passé beaucoup de temps à découvrir Rennes.\n\nEmail DGOS / copie ARS.\n\nMonsieur le Directeur/Madame la directrice de l'établissement Marisol en Touraine, \nNous vous informons que l'ONDAM arrêté pour cette année s'élève à 2.3%. \nMerci d'en prendre connaissance, et de mettre en oeuvre les actions nécessaires par rapport à l'effort réel de votre établissement qui est estimé à 4.5%\n");

		OfficeComputerManager.instance.AddNewMail("Pewdiepie","Image de chat trop rigolo","Erreur!Contactez le service technique!\n ALERTE SECURITE!");
	}

	public void HideAllObjectsOutliner(){
		
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
