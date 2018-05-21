using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour {

	[HideInInspector]
	public Sprite visualToShow;
	[HideInInspector]
	public string completeDefinition; 
	[HideInInspector]
	public string achievementName; 
	public int achievementScore;
	public Text myAchievementNameTxt;
	public Text myAchievementDescTxt;

	public Text myAchievementScoreTxt;
	public Image myVisualDisplayer;
	public bool achievementIsLocked = true;

	public void InitializeAchievementUI(string entryT, string fullDefinition, int score)
	{
		achievementName = entryT;
		myAchievementNameTxt.text = achievementName;
		completeDefinition = fullDefinition;
		myAchievementDescTxt.text = completeDefinition;
		achievementScore = score;
		myAchievementScoreTxt.text = score.ToString ();
		if (visualToShow) 
		{
			myVisualDisplayer.sprite = visualToShow;
		}
	}
		
}
