using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using cakeslice;

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

	[Header("Les propriétés a compléter au besoin:")]

	[Tooltip("L'outliner présent sur le modèle 3D")]
	public Outline outliner;
	public Camera npcCam;

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
		//il faut le laisser actif de base pour qu'il s'enregistre auprés du outlineeffect sur camera!
		if (outliner) 
		{
			//on le désactive donc pour le moment si il existe.
			outliner.enabled = false;
		}

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

	#region Utilitaires
	public void ToggleMyCam(bool camState)
	{
		npcCam.enabled = camState;
	}
	#endregion
}
