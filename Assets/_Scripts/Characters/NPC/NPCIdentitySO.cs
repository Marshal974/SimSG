using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPC", menuName = "SimangoSG/NPCIdentity", order = 2)]
public class NPCIdentitySO : ScriptableObject 
{
	//On peut se servir de ca pour créer une "bibliothèque" de PNJ.

	public string npcName;
	public string npcJob;

}
