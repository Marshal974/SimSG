using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThis : MonoBehaviour {
	
	//A mettre sur un gameobject pour qu'il soit pas détruit en cas de load.

	void Start ()
	{
		DontDestroyOnLoad (gameObject);
	}

}
