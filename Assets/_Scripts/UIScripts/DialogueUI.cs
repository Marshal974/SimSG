using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour 
{

	public Image graphDisplayer;

	void Start () 
	{
		//On s'enregistre auprès du moduleUIManager
		ModuleUIManager.instance.dialogueUI = this;
	}
}
