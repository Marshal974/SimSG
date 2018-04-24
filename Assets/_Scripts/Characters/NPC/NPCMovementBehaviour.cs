using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NPCGeneralBehaviour))]
public class NPCMovementBehaviour : MonoBehaviour 
{
	//Il sert a déplacer les pnj de plusieurs facons.
	//On peut le désactiver quand on en a pas besoin hein.
	//Toute configuration du pnc se fait dans "npcgeneralbehaviour" pas ici !! 

	public Animator anim;//aller chercher le modéle du PNJ pour compléter cette variable.

	[HideInInspector]
	public int patrolRange; //configurer dans le npcgeneral behaviour(présent sur l'objet obligatoirement), pas ici!

	[HideInInspector]
	public NPCPatrolRoad predefinedRoad;

	#region private variables
	Transform currentTarget; //peut être vide.

	NavMeshAgent agent;

	bool walking;

	bool isPatroling;
	bool isFollowingTarget;
	bool isOnPatrolRoad;
	bool patrolRoadIsRandom;

	Vector3 targetPatrolPoint;
	Vector3 patrolStartPos;

	int currentPatrolRoadPointIndex;

	float minPauseTimeOnPatrolRoad;
	float maxPauseTimeOnPatrolRoad;
	#endregion

	#region MonoB functions

	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Start()
	{

		//On gère des exceptions.
		if (isFollowingTarget && isPatroling) 
		{
			Debug.Log ("attention il ne peut pas patrouiller et follow en mm tps!Allons bon mon ami!");
			Debug.Log ("mode follow selectionner");
			isPatroling = false;
		}
	}

	void Update () 
	{
		CheckAnimationBehaviour ();
	}

	void OnEnable()
	{
		//on clear le path au cas ou  / on s'assure que les variables sont bien configuré etc..
		walking = false;
		agent.isStopped = false;
		agent.ResetPath ();
	}

	void OnDisable()
	{
		//on s'assure qu'en cas de désactivation du script, aucun prob ne peut survenir.
		walking = false;

		//ce check permet juste de s'assurer qu'on est pas en train de quitter le jeu.
		if (anim.isActiveAndEnabled) 
		{
			anim.SetBool ("IsWalking", walking);
			agent.isStopped = true;
		}
	}

	#endregion

	#region Les fonctions de déplacement

	/// <summary>
	/// Aller vers une cible en donnant une position.
	/// </summary>
	/// <param name="targetPos">Target position.</param>
	public void GoToTarget( Vector3 targetPos)
	{
		agent.isStopped = false;
		walking = true;
		anim.SetBool ("IsWalking", walking);
		agent.SetDestination (targetPos);
	}

	//On arrête tous les ordres de déplacement!
	void StopMovementOrders()
	{
		StopPatroling ();
		StopFollowingPatrolRoad ();
		StopFollowingTarget ();
	}

	#region la patrouille

	public void StartPatroling(int newPatrolRange)
	{
		StopMovementOrders ();
		patrolStartPos = transform.position;
		patrolRange = newPatrolRange;
		isPatroling = true;
		ChangeTargetPatrolPoint ();
	}

	public void StopPatroling()
	{
		isPatroling = false;
	}

	void ChangeTargetPatrolPoint()
	{
		targetPatrolPoint = new Vector3(patrolStartPos.x+Random.Range(0,patrolRange),0,patrolStartPos.z+Random.Range(0,patrolRange));
		GoToTarget (targetPatrolPoint);
	}
	#endregion

	#region le followTarget
	/// <summary>
	/// Le npc va suivre la cible.Invoquez StopFollowingTarget pour arrêter le follow!
	/// </summary>
	/// <param name="target">la cible.</param>
	public void StartFollowingTarget(Transform target)
	{
		StopMovementOrders ();
		currentTarget = target;
		isFollowingTarget = true;
		ActualizeFollowPath ();
	}

	void ActualizeFollowPath()
	{
		GoToTarget (currentTarget.position);
	}

	//Doit être invoquer une fois la destination finale atteinte ou l'arrêt du suivi désiré.
	public void StopFollowingTarget()
	{
		isFollowingTarget = false;
		currentTarget = null;
	}
	#endregion

	#region follow predefined path (patrolroad)

	public void StartFollowingPatrolRoad(NPCPatrolRoad newRoad, bool randomRoad, float minPause, float maxPause)
	{
		StopMovementOrders ();
		minPauseTimeOnPatrolRoad = minPause;
		maxPauseTimeOnPatrolRoad = maxPause;
		patrolRoadIsRandom = randomRoad;
		predefinedRoad = newRoad;
		isOnPatrolRoad = true;
		currentPatrolRoadPointIndex = 0;
		GoToNextPatrolPoint ();
	}

	void GoToNextPatrolPoint()
	{
		GoToTarget (predefinedRoad.allPatrolPoints [currentPatrolRoadPointIndex].position);

		if (!patrolRoadIsRandom) 
		{
			if (currentPatrolRoadPointIndex == predefinedRoad.allPatrolPoints.Length - 1) 
			{
				//On a atteind le dernier point de patrouille.
				currentPatrolRoadPointIndex = -1;
			}
			currentPatrolRoadPointIndex++;
		} else 
		{
			currentPatrolRoadPointIndex = Random.Range (0, predefinedRoad.allPatrolPoints.Length);
		}
	}

	//A appelé pour arrêter la patrouille.
	public void StopFollowingPatrolRoad()
	{
		predefinedRoad = null;
		isOnPatrolRoad = false;
	}

	#endregion



	#endregion

	#region Utilitaires
	//on évite qq bugs potentiel grace a cette fonction. 
	//elle permet de s'assurer que l'animator controller est bien configurer au bon moment.
	void CheckAnimationBehaviour()
	{
		if (agent.remainingDistance <= agent.stoppingDistance) 
		{

			if (!agent.hasPath || Mathf.Abs (agent.velocity.sqrMagnitude) < float.Epsilon) 
			{
				if (walking)
				{
					if (isPatroling) 
					{
						Invoke ("ChangeTargetPatrolPoint", Random.Range (1,5));
					}
					if (isOnPatrolRoad) 
					{
						Invoke("GoToNextPatrolPoint",Random.Range(minPauseTimeOnPatrolRoad,maxPauseTimeOnPatrolRoad));
					}
					if (isFollowingTarget) 
					{
						ActualizeFollowPath ();
					}
					walking = false;
					anim.SetBool ("IsWalking", walking);
				}
			}
		} else 
		{
			if (!walking) 
			{
				walking = true;
				anim.SetBool ("IsWalking", walking);
			}
		}
	}
	#endregion
}
