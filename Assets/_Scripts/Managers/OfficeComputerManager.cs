using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeComputerManager : MonoBehaviour 
{

	//Gère l'ordinateur in game dans le bureau du joueur.
	//Permet d'envoyer de nouveaux mails / Les gérer en général.
	public static OfficeComputerManager instance;

	public GameObject mailPrefab;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else 
		{
			Debug.Log ("ya 2 managers d'office computer");
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Adds a new mail in the computerUI.
	/// </summary>
	/// <param name="sender">Sender.</param>
	/// <param name="objectMessage">Object message.</param>
	/// <param name="mailContent">Mail content.</param>
	public void AddNewMail(string sender, string objectMessage, string mailContent)
	{
		GameObject go = Instantiate (mailPrefab);
		go.GetComponent<MailScript> ().sender.text = sender;
		go.GetComponent<MailScript> ().objectMess.text = objectMessage;
		go.GetComponent<MailScript> ().mailContent = mailContent;
		go.transform.SetParent (ModuleUIManager.instance.computerUI.allMessagesPanel.transform);
		go.transform.position = Vector3.zero;
		go.transform.localScale = Vector3.one;
		go.transform.SetAsFirstSibling ();
		AlertMessageManager.instance.CreateAnAlert ("Vous avez recu un email.",1);
		//Rajouter ici un appel au systeme d'alerte IG.
	}

}
