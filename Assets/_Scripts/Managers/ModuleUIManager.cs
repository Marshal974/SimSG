using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleUIManager : MonoBehaviour {

	public static ModuleUIManager instance;

	public InGameOptions ingameOptions;
	public HelpUI helpUI;
	public PlayerResourcesUI playerResourcesUI;
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("2 moduleUIManager");
			Destroy (gameObject);
		}
	}
}
