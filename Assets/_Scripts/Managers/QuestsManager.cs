using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestsManager : MonoBehaviour 
{

	public static QuestsManager instance;
	public UnityEvent followMeQuest;
	public UnityEvent explainFinanceRoomQuest;

	public GameObject questActivatorPrefab;
	public GameObject questTrail;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else 
		{
			Debug.Log ("il y a 2 quests managers");
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// A appelé depuis n'importe ou pour démarrer une quête quelconque de préconfigurer dans ce quest manager.
	/// </summary>
	/// <param name="questToStart">Quest to start.</param>
	public void StartNewQuest(AllEnum.allQuests questToStart)
	{
		ModuleUIManager.instance.HideAllUI ();
		switch (questToStart) 
		{
		case AllEnum.allQuests.followMe:
			followMeQuest.Invoke ();
			break;
		case AllEnum.allQuests.financeRoom:
			explainFinanceRoomQuest.Invoke ();
			break;
		default:
			ModuleUIManager.instance.ShowAllUI ();

			Debug.Log ("tu essai de lancer une quête non référencer j'imagine?");
			break;
		}
	}

	//A appelé a la fin de chaque quête pour démarrer les events généraux.
	public void EndCurrentQuest()
	{
		ModuleUIManager.instance.ShowAllUI ();

	}

	/// <summary>
	/// Instantiate a quest activator triggerer at a specific location.
	/// </summary>
	/// <param name="activatorPos">Activator position.</param>
	/// <param name="questToActivate">Quest to activate.</param>
	public void AddQuestActivator(Vector3 activatorPos, AllEnum.allQuests questToActivate, float radius)
	{
		GameObject go = Instantiate (questActivatorPrefab);
		go.GetComponent<QuestTriggerActivator> ().questToStart = questToActivate;
		go.transform.position = activatorPos;
		go.GetComponent<SphereCollider> ().radius = radius;
	}
}
