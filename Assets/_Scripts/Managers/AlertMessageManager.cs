using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlertMessageManager : MonoBehaviour 
{

	//Gestion du systeme d'alerte avec les 3 niveaux d'alertes personnalisable.
	public static AlertMessageManager instance;
	public GameObject alertPrefab;
	 
	public Color lowpriorityAlertColor;
	public Color normalAlertColor;
	public Color importantAlertColor;

	AudioSource audioS;
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else 
		{
			Debug.Log ("on a 2 alert managers");
		}
	}

	void Start()
	{
		audioS = GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Creates an alert.
	/// </summary>
	/// <param name="alertMess">Alert mess.</param>
	/// <param name="alertLvl">Alert priority lvl1 2 or 3.</param>
	public void CreateAnAlert(string alertMess, int alertLvl)
	{
		GameObject Go = Instantiate (alertPrefab);
		Go.transform.SetParent(ModuleUIManager.instance.alertUI.allAlertsPanel);
		Go.transform.SetAsFirstSibling ();
		Go.transform.localScale = Vector3.one;
		Go.GetComponent<AlertMessageScript> ().alertTxt.text = alertMess;
		switch (alertLvl) {

		case 1:
			Go.GetComponent<AlertMessageScript> ().alertVisual.color = lowpriorityAlertColor;
			audioS.PlayOneShot (SoundsManager.instance.soundsSO.successSnd);
			break;
		case 2:
			Go.GetComponent<AlertMessageScript> ().alertVisual.color = normalAlertColor;
			audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd);

			break;
		case 3:
			Go.GetComponent<AlertMessageScript> ().alertVisual.color = importantAlertColor;
			audioS.PlayOneShot (SoundsManager.instance.soundsSO.errorSnd);

			break;
		default:
			Debug.Log ("ce niveau d'alerte est inconnu ! ");
			break;
		}

	}
}
