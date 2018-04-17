using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerClickToMove : MonoBehaviour {

	public LayerMask interactableLayer;

	public float shootDistance = 10f;
	public float shootRate = .5f;
	public Animator anim;
//	public PlayerShooting shootingScript;

	private NavMeshAgent navMeshAgent;
	private Transform targetedEnemy;
	private Ray shootRay;
	private RaycastHit shootHit;
	private bool walking;
	private bool enemyClicked;
	private float nextFire;

	// Use this for initialization
	void Awake () 
	{
//		anim = GetComponent<Animator> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetButtonDown ("Fire2")) 
		{
			
			if (Physics.Raycast(ray, out hit, 100,interactableLayer))
			{
//				if (hit.collider.CompareTag("Enemy"))
//				{
//					targetedEnemy = hit.transform;
//					enemyClicked = true;
//				}

//				else
//				{
					walking = true;
					enemyClicked = false;
					navMeshAgent.destination = hit.point;
					navMeshAgent.Resume();
				anim.SetBool ("IsWalking", walking);

//				}
			}
		}

		if (enemyClicked) {
			MoveAndShoot();
		}

		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			if (!navMeshAgent.hasPath || Mathf.Abs (navMeshAgent.velocity.sqrMagnitude) < float.Epsilon) {
				if (walking){
					walking = false;
				anim.SetBool ("IsWalking", walking);
			}
			}

		} else {
			if (!walking) {
				walking = true;
				anim.SetBool ("IsWalking", walking);

				Debug.Log (walking);
			}
		}

	}

	private void MoveAndShoot()
	{
		if (targetedEnemy == null)
			return;
		navMeshAgent.destination = targetedEnemy.position;
		if (navMeshAgent.remainingDistance >= shootDistance) {

			navMeshAgent.Resume();
			walking = true;
		}

		if (navMeshAgent.remainingDistance <= shootDistance) {

			transform.LookAt(targetedEnemy);
			Vector3 dirToShoot = targetedEnemy.transform.position - transform.position;
			if (Time.time > nextFire)
			{
				nextFire = Time.time + shootRate;
//				shootingScript.Shoot(dirToShoot);
			}
			navMeshAgent.Stop();
			walking = false;
		}
	}
}
