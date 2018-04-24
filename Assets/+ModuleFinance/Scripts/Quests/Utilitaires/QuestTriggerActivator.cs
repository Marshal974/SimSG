using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerActivator : MonoBehaviour 
{

	public AllEnum.allQuests questToStart;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			QuestsManager.instance.StartNewQuest(AllEnum.allQuests.followMe);
			Destroy (this);
		}
	}
}
