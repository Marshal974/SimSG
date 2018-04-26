using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertUI : MonoBehaviour 
{
	public Transform allAlertsPanel;
	// Use this for initialization
	void Start () 
	{
		//on s'enregistre
		ModuleUIManager.instance.alertUI = this;
		ModuleUIManager.instance.allCanvases.Add (GetComponent<Canvas> ());
	}
	

}
