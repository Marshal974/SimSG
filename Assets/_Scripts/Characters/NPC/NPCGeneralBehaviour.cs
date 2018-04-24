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
	[Header("Activer la patrouille random a proximité.")]
	public bool randomPatrolSector; //patrouille aléatoire du secteur dont le range est défini ci dessous:
	[Range(1,100)] public int randomPatrolSectorRange;

	[Header("Si non, ajouter une patrolRoad a suivre et configurez la ici:")]
	//Si random patrol sector est pas cocher, on peut aussi:
	[Tooltip("Ajouter ici une npcPatrolRoad si désiré")]
	public NPCPatrolRoad specificPatrolRoad;

	[Tooltip("Si coché, le joueur ne suivra pas les points de la route dans l'ordre.")]
	public bool randomizePatrolRoadPoints;

	[Tooltip("Dois-je marquer une pause entre 2 points de patrouille?")]
	public bool pauseBetweenPatrolPoints;

	public float minimumPauseTime;
	public float maximumPauseTime;

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
		npcMovementB = GetComponent<NPCMovementBehaviour> ();


		//On s'enregistre.
		NPCManager.instance.allActiveNPC.Add (gameObject);

		//on active les comportements appropriées.
		if (randomPatrolSector) 
		{
			npcMovementB.StartPatroling (randomPatrolSectorRange);
		} else 
		{
			if (specificPatrolRoad != null) 
			{
				npcMovementB.StartFollowingPatrolRoad (specificPatrolRoad, randomizePatrolRoadPoints, minimumPauseTime, maximumPauseTime);
			} 
		}
	}

	#endregion

}
