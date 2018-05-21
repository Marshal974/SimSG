using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinanceOffice : MonoBehaviour {

	//Peu voir pas utile pour le moment mais ca peut servir donc j'le met pour plus tard:

	//Ayé il sert:
	//il référencie le phone et le pc pour les emails, pratique pour afficher et cacher les visuels d'alerte par exemple

	public static FinanceOffice instance;

	public Phone officePhone;
	public Computer officeComputer;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		} else 
		{
			Debug.Log ("il a deux salles de finance la!");
			Destroy (gameObject);
		}
	}
}
