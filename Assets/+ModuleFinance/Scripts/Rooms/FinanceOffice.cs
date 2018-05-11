using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinanceOffice : MonoBehaviour {

	//Peu voir pas utile pour le moment mais ca peut servir donc j'le met pour plus tard:

	public static FinanceOffice instance;

	public Phone officePhone;

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
