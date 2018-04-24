using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjectScript : MonoBehaviour {

	public bool isInteractable;

	public Transform playerDesiredPos;

	public UnityEvent theActionToDoOnInteraction;

	public void activateThisObject()
	{
		if (isInteractable) {
			theActionToDoOnInteraction.Invoke ();
		}
	}
}
