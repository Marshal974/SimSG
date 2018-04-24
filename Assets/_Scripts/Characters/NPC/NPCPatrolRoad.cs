using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrolRoad : MonoBehaviour 
{

	//Contient en enfant tous les points de patrouille possible.
	//On peut les dupliquer, les déplacer a souhait.

	[Tooltip("Faire glisser ici tous les enfants.")]
	public Transform[] allPatrolPoints;


	#region monobehaviour

	void Start()
	{
		//On s'enregistre auprès du NPC Manager;
		NPCManager.instance.allPatrolRoads.Add(this);
	}

	#endregion


}
