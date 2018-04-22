﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour 
{

	//Ce script gère les ressources du joueur : 

	#region variables public mais get et set.

	public int agentsCount
	{
		get
		{ 
			return _agentsCount;
		}
		set
		{ 
			_agentsCount = value;
			ModuleUIManager.instance.playerResourcesUI.agentsCountDisplay.text = value.ToString ();
		}
	}


	public int patientsCount
	{
		get
		{ 
			return _patientsCount;
		}
		set
		{ 
			_patientsCount = value;
			ModuleUIManager.instance.playerResourcesUI.patientsCountDisplay.text = value.ToString ();
		}
	}

	//Il s'agit de l'argent du joueur, il faut le voir comme le score du module un peu aussi.
	//il faut un certain score a la fin pour gagner la partie.
	public int playerGold
	{
		get
		{
			return _playergold;
		}
		set
		{
			_playergold = value;
			ModuleUIManager.instance.playerResourcesUI.playerGoldDisplay.text = value.ToString ();
		}
	}

	//le climat social dans l'hopital. La jauge de prestige un peu aussi / de bien être.
	public int socialClimate
	{
		get
		{ return _socialClimate; 
		}
		set
		{  
			_socialClimate = value;
			ModuleUIManager.instance.playerResourcesUI.UpdateSocialClimateUI (value) ;			
		}
	}

	//le mois en cours:
	public AllEnum.Months currentMonth
	{
		get
		{
			return _currentMonth;
		}
		set
		{
			_currentMonth = value;
			ModuleUIManager.instance.playerResourcesUI.currentMonthDisplay.text = value.ToString ();
		}
	} 
	#endregion

	#region variables privés utilisés par les get set nottament

	int _patientsCount;
	int _agentsCount;
	int _playergold;
	int _socialClimate;
	AllEnum.Months _currentMonth;


	#endregion

	void Start()
	{
		Invoke ("ChangeResourcesForTest", 1f);
	}

	void ChangeResourcesForTest()
	{
		playerGold = 10000000;
		socialClimate = 20;
		currentMonth = AllEnum.Months.april;
		patientsCount = 40;
		agentsCount = 25;
	}
}
