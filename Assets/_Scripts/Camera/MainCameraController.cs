using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour 
{
	//Ce script gère le positionnement de la caméra 
	//Il sagit du mode principale de suivi de la caméra. 
	//une référence a ce script est trouvable sur le GameManager.
	//il consomme bcp de ressources (pour des raisons de fluidité du mouvement) et doit donc être désactiver durant les minijeux.


	public float camLerpSpeed; //la vitesse de la cam pour atteindre sa position
	public Vector3 offset; //le offset désirée pour la caméra : régler ca atruntime

	private Transform playerTransformRef;
	private Vector3 targetPos;

	#region MonoB functions

	void Start () 
	{
		//on garde en référence le transform du joueur
		playerTransformRef = InGameManager.instance.playerObj.transform;
	}
	
	void Update () 
	{
		//on défini en update la position souhaitée.
		targetPos = new Vector3 (playerTransformRef.position.x+offset.x, playerTransformRef.position.y+offset.y, playerTransformRef.position.z+offset.z);
	}

	void LateUpdate()
	{
		//on attend le late update pour pas surcharger et être sur que c'est bien la dernière chose faites.
		//on bouge avec swag vers la position désirée.
		transform.position = Vector3.Lerp (transform.position, targetPos, camLerpSpeed * Time.deltaTime);
	}
	#endregion
}
