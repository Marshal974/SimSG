using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTriggerer : MonoBehaviour 
{

	//il suffit d'activer ce script pour que l'achievement soit unlock si il ne l'est pas déja.

	public AchievementSO theAchievementToTrigger;

	void OnEnable()
	{
		if (AchievementsManager.instance.CheckIfAchievementIsLocked (theAchievementToTrigger)) 
		{
			AchievementsManager.instance.UnlockAchievement (theAchievementToTrigger);
		}
	}
}
