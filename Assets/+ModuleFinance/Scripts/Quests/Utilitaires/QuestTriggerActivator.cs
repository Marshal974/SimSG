using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerActivator : MonoBehaviour 
{

	public bool canBeRepeated;
	public AllEnum.allQuests questToStart;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			QuestsManager.instance.StartNewQuest(questToStart);
			if (!canBeRepeated) {
				Destroy (this);
			}
		}
	}
}
