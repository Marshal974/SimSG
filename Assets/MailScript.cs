using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailScript : MonoBehaviour 
{
	[HideInInspector]
	public Text sender;
	[HideInInspector]
	public Text objectMess;
	[HideInInspector]
	public string mailContent;

	public void ShowMessageInMainPanel()
	{
		ModuleUIManager.instance.computerUI.ShowMessage (sender.text, objectMess.text, mailContent);
	}
}
