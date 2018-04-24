using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestsManager : MonoBehaviour 
{

	public static QuestsManager instance;
	public UnityEvent followMeQuest;

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

	public void StartNewQuest(AllEnum.allQuests questToStart)
	{
		switch (questToStart) 
		{
		case AllEnum.allQuests.followMe:
			followMeQuest.Invoke ();
			break;
		default:
			Debug.Log ("tu essai de lancer une quête non référencer j'imagine?");
			break;
		}
	}
}
