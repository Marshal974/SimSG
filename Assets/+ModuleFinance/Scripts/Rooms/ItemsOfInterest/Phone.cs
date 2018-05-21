﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Phone : MonoBehaviour 
{

	//Référencer dans le singleton de l'officeRoom

	public GameObject ringingVisualCanvasObj;

	[HideInInspector]
	public bool isRinging;

//	[HideInInspector]
	public UnityEvent theActionToDoWhenAnswering;

	void Start()
	{
		//on s'enregistre dans la salle.
		FinanceOffice.instance.officePhone = this;
	}

	public void StartRinging()
	{
		if (!isRinging) {
			StartCoroutine (RingThePhone ());
		}
	}
	IEnumerator RingThePhone()
	{
		isRinging = true;
		ringingVisualCanvasObj.SetActive (true);
		GetComponent<InteractableObjectScript> ().outliner.enabled = true;
		GetComponent<AudioSource> ().enabled = true;
		AlertMessageManager.instance.CreateAnAlert ("Le téléphone sonne!", 3);
		while (isRinging) 
		{
			yield return new WaitForEndOfFrame ();
		}
		GetComponent<AudioSource> ().enabled = false;
		yield return new WaitForEndOfFrame ();

	}

	public void AnswerTheCall()
	{
		if (isRinging) 
		{			
			ringingVisualCanvasObj.SetActive (false);

			theActionToDoWhenAnswering.Invoke ();
			theActionToDoWhenAnswering.RemoveAllListeners ();
			isRinging = false;
			GetComponent<InteractableObjectScript> ().outliner.enabled = false;
		}
	}

}
