using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerClickToMove : MonoBehaviour {

	//ce script permet de déplacer le joueur.
	//il peut être désactiver en toute sécurité quand on veut pas que le joueur se déplace.

	[Tooltip("Les layers qu'on peut raycast.")]
	public LayerMask interactableLayer;  //la ou le joueur peut aller en gros ^^
	public float maxInteractionDistance = 2.5f;
	public Animator anim;//aller chercher le modéle du joueur pour compléter cette variable.

//	[HideInInspector]
	public InteractableObjectScript currentInteractableObjectTarget;

	private NavMeshAgent navMeshAgent;
	private bool walking; //le joueur marche t-il actuellement?
	private RaycastHit hit; //sert pour le raycast du joueur.

	#region MonoB functions

	void Awake () 
	{
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	void Update () 
	{
		//Si le joueur clic / touch :
		if (Input.GetMouseButtonUp(0)) 
		{
			CastRayForMoving ();
		}

		CheckAnimationBehaviour ();
	}

	void OnEnable()
	{
		//on clear le path au cas ou  / on s'assure que les variables sont bien configuré etc..
		walking = false;
		navMeshAgent.isStopped = false;
		navMeshAgent.ResetPath ();
	}

	void OnDisable()
	{
		//on s'assure qu'en cas de désactivation du script, aucun prob ne peut survenir.
		walking = false;

		//ce check permet juste de s'assurer qu'on est pas en train de quitter le jeu(le mode play)
		if (anim.isActiveAndEnabled) 
		{
		anim.SetBool ("IsWalking", walking);
		navMeshAgent.isStopped = true;
		}
	}

	#endregion

	#region déplacement du joueur

	public void GoToTarget( Vector3 targetPos)
	{
		navMeshAgent.isStopped = false;
		walking = true;
		anim.SetBool ("IsWalking", walking);
		navMeshAgent.SetDestination (targetPos);
	}

	//on cast un ray pour dire au joueur ou il doit aller
	void CastRayForMoving()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 100,interactableLayer))
		{
			currentInteractableObjectTarget = null;

			if (hit.transform.gameObject.layer == LayerMask.NameToLayer("InteractableObject")) 
			{
				currentInteractableObjectTarget = hit.transform.GetComponent<InteractableObjectScript> ();
				if (Vector3.Distance (transform.position, hit.point) > maxInteractionDistance) 
				{
					walking = true;
					anim.SetBool ("IsWalking", walking);
					navMeshAgent.isStopped = false;

					navMeshAgent.destination = currentInteractableObjectTarget.playerDesiredPos.position;
				} 
				else 
				{
					walking = false;
					anim.SetBool ("IsWalking", walking);
					navMeshAgent.isStopped = true;
					currentInteractableObjectTarget.activateThisObject ();
				}
			} 
			else 
			{
				walking = true;
				anim.SetBool ("IsWalking", walking);
				navMeshAgent.isStopped = false;
				navMeshAgent.destination = hit.point;
			}
		}
	}

	//on évite qq bugs potentiel grace a cette fonction. 
	//elle permet de s'assurer que l'animator controller est bien configurer au bon moment.
	void CheckAnimationBehaviour()
	{
			if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) 
			{
				if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon) 
				{
					if (walking)
					{
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
