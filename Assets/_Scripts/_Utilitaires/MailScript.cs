using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MailScript : MonoBehaviour 
{
	[HideInInspector]
	public Text sender;
	[HideInInspector]
	public Text objectMess;
	[HideInInspector]
	public string mailContent;
	public Image unreadMailImg; //L'image a désactiver si le mail est lu.
	public UnityEvent OnFirstRead; // Appeler quand le mail est lu pour la première fois.

	bool read; //Le mail a t-il déja été lu ? 

	public void ShowMessageInMainPanel()
	{
		if (read == false) 
		{
			unreadMailImg.enabled = false;
			read = true;
			OnFirstRead.Invoke ();
		}
		ModuleUIManager.instance.computerUI.ShowMessage (sender.text, objectMess.text, mailContent);
	}
}
