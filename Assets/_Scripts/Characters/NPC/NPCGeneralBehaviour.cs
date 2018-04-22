using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NPCMovementBehaviour))]
[RequireComponent(typeof(NavMeshAgent))]

public class NPCGeneralBehaviour : MonoBehaviour 
{
	//C'est ici qu'on configure notre PNJ.
	//On défini ici ce qu'il est capable ou pas de faire.
	//On défini aussi qui il est.
	//On l'enregistre auprés du NPCManager
	#region public variables
	[Header("Ce qu'il peut faire:")]
	public bool canPatrol; //etc
	[Range(1,100)] public int patrolRange;

	[HideInInspector]
	public NPCMovementBehaviour npcMovementB;

	#endregion

	#region private variables
	NavMeshAgent agent;

	#endregion

	#region monobehaviour
	void Start () 
	{
		//on configure certaines variables.
		npcMovementB = GetComponent<NPCMovementBehaviour>();


		//On s'enregistre.
		NPCManager.instance.allActiveNPC.Add (gameObject);

		//on active les comportements appropriées.
		if (canPatrol) 
		{
			npcMovementB.StartPatroling (patrolRange);
		}
	}

	#endregion

}
