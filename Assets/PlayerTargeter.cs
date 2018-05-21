using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeter : MonoBehaviour {

	//ca permet d'afficher l'endroit ou le joueur va se déplacer.
	//il se référence automatiquement auprès du clicktomove script sur le player.

	public bool isActive;
	// Use this for initialization

	void Start()
	{
		//On référence l'objet.
		InGameManager.instance.playerObj.GetComponent<PlayerClickToMove> ().clicTargeterObj = gameObject;

	}
	void OnEnable()
	{
		isActive = true;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (!isActive) 
		{
			return;
		}
		if (other.tag == "Player") 
		{
			isActive = false;
			gameObject.SetActive (false);
		}
		
	}
}
