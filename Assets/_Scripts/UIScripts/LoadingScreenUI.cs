using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenUI : MonoBehaviour {

	public GameObject loadingPanel;

	void Start()
	{
		//On s'enregistre auprés du loading screen manager.
		LoadingScreenManager.instance.loadingUI = this;
	}
}
