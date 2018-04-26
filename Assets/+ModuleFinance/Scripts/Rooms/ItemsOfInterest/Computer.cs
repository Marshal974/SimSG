using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {

	public void OpenComputerUI()
	{
		ModuleUIManager.instance.computerUI.OpenComputerPanel ();
	}
}
