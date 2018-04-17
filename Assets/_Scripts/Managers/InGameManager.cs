using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour {


	public static InGameManager instance;

	public GameObject playerObj;
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("Two Managers here");
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
