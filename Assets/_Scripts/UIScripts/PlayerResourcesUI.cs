using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResourcesUI : MonoBehaviour {

	public GameObject ResourcesPanel;

	void Start () 
	{
		
		//On s'enregistre auprès du moduleUIManager
		ModuleUIManager.instance.playerResourcesUI = this;
	}

	public void ToggleResourcesUI()
	{
		ResourcesPanel.SetActive (!ResourcesPanel.activeSelf);
	}

}
