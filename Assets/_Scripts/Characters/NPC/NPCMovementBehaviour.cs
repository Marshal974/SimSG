using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovementBehaviour : MonoBehaviour 
{
	//Il sert a déplacer les pnj de plusieurs facons.
	//On peut le désactiver quand on en a pas besoin hein.

	public Animator anim;//aller chercher le modéle du PNJ pour compléter cette variable.

	[HideInInspector]
	public int patrolRange; //configurer dans le npcgeneral behaviour, pas ici!

	#region private variables
	Transform currentTarget; //peut être vide.

	NavMeshAgent agent;
	bool walking;

	bool isPatroling;
	Vector3 targetPatrolPoint;
	Vector3 patrolStartPos;
	#endregion

	#region MonoB functions

	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Start()
	{
		//pour faire un test:
		GoToTarget (InGameManager.instance.playerObj.transform.position);
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

	public void StartPatroling(int newPatrolRange)
	{
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
