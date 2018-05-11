using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryItem : MonoBehaviour 

{
	[HideInInspector]
	public Sprite visualToShow; //Le visuel a montrer si besoin.
	[HideInInspector]
	public string completeDefinition; //La définition complète
	[HideInInspector]
	public string entryTerm; //le terme a définir.

	public Text myEntryTermTxt;

	public void InitializeTheEntryInGlossary(string entryT, string fullDefinition)
	{
		entryTerm = entryT;
		myEntryTermTxt.text = entryTerm;
		completeDefinition = fullDefinition;
	}

	public void ShowThisEntryDetails()
	{
		GlossaryManager.instance.ShowSpecificEntry (entryTerm, completeDefinition);
		if (visualToShow) 
		{
			GlossaryManager.instance.ShowSpecificEntryVisual (visualToShow);
		}

	}

	//Obsolète / Rejeter :

	//Ca complique la vie plus qu'autre chose. Voir solution au moment du spawn de l'entrée.
//	public void InitializeTheEntryInGlossary(string entryTerm, string fullDefinition, Sprite visual)
//	{
//		InitializeTheEntryInGlossary (entryTerm, fullDefinition);
//		visualToShow = visual;
//	}
}
