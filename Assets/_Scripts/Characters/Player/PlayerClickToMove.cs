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
	public Animator anim;//aller chercher le modéle du joueur pour compléter cette variable.

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

		//ce check permet juste de s'assurer qu'on est pas en train de quitter le jeu.
		if (anim.isActiveAndEnabled) 
		{
		anim.SetBool ("IsWalking", walking);
		navMeshAgent.isStopped = true;
		}
	}

	#endregion

	#region déplacement du joueur

	//on cast un ray pour dire au joueur ou il doit aller
	void CastRayForMoving()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 100,interactableLayer))
		{
			////A utiliser plus tard pour détecter les objets d'intêret.
			//				if (hit.collider.CompareTag("Cequetuveux"))
			//				{
			//					Cequetuveux= hit.transform;
			//					Clicked = true;
			//				}
			if (hit.transform.gameObject.layer == LayerMask.NameToLayer ("UI")) 
			{
				return;
			}
	
			walking = true;
			navMeshAgent.destination = hit.point;
			navMeshAgent.isStopped = false;
			anim.SetBool ("IsWalking", walking);
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
