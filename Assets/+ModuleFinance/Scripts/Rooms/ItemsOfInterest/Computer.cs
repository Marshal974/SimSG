using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {



	public GameObject mailVisualCanvasObj;


	public void OpenComputerUI()
	{
		ModuleUIManager.instance.computerUI.OpenComputerPanel ();
		if (!GetComponent<AchievementTriggerer> ().enabled) 
		{
			GetComponent<AchievementTriggerer> ().enabled = true;
		}
	}
}
