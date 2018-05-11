using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlossaryItem", menuName = "SimangoSG/Glossary", order = 2)]
public class GlossaryItemSO : ScriptableObject 
{
	//ce SO a pour mission de contenir tous les sons récurrents du jeu.
	//on peut, en le remplacant, changer directement tous les sons du jeu ^^ merveilleux oui oui.

	public Sprite visualToDisplay; //si tu souhaites montrer une image associé a cette entrée, met la là.
	public string entryName; //Le nom de l'entrée.
	[TextArea(3,10)]public string entryDefContent; //la définition complète et textuel.


}
