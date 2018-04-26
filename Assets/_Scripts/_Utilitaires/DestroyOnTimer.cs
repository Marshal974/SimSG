using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour {

	public float objectLifeTime;

	void Start () 
	{
		Invoke ("DestroyThisGameObject", objectLifeTime);	
	}

	void DestroyThisGameObject()
	{
		Destroy (gameObject);
	}
}
