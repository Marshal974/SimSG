using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using cakeslice;

public class InteractableObjectScript : MonoBehaviour 
{
	//A mettre sur tout objet qu'on souhaite rendre interactif dans le jeu.
	//Il faut (pour des raisons de cohérence) lui assigner un outline.

	public bool isInteractable; //Est ce qu'on peut utiliser l'objet??
	public Outline outliner; //L'outline autour de l'objet interactif.
	public Transform playerDesiredPos; //L'endroit ou le joueur doit se rendre si il clic sur l'objet et qu'il est loin.

	public UnityEvent theActionToDoOnInteraction; //quoi faire quand on clic.

	public void activateThisObject()
	{
		if (isInteractable) {
			theActionToDoOnInteraction.Invoke ();
		}
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			outliner.enabled = true;
			if (other.GetComponent<PlayerClickToMove> ().currentInteractableObjectTarget != null && other.GetComponent<PlayerClickToMove> ().currentInteractableObjectTarget == this) 
			{
				activateThisObject ();
			}
		}
	}
	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			outliner.enabled = false;
		}
	}
}
