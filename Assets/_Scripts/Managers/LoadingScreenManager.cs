using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour {


	public static LoadingScreenManager instance;

	public LoadingScreenUI loadingUI;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else 
		{
			Debug.Log ("on a 2 loading screen");
			Destroy (gameObject);
		}
	}

	//Tout est géré automatiquement sur le loading panel.
	public void ShowLoadingScreen()
	{
		loadingUI.loadingPanel.SetActive (true);

	}
}
