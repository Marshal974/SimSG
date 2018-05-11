using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour 
{

	// gestion des cinématiques du jeu.

	public static TimelineManager instance;

	[Header("Les cutscenes de l'écran de bienvenue.")]
	public PlayableAsset welcomeCutscenePart1;
	public PlayableAsset welcomeCutscenePart2;

	PlayableDirector playableDirector;

	#region monob territory
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else 
		{
			Debug.Log ("ya 2 timeline managers");
			Destroy (gameObject);
		}
	}

	void Start()
	{
		playableDirector = GetComponent<PlayableDirector> ();
	}

	#endregion

	#region welcome cutscene
	public void PlayWelcomeCutscene(int cutscenePart)
	{
		switch (cutscenePart) 
		{
		case 1:
			PlayWelcomeCutscenePart1 ();
			break;
		case 2:
			PlayWelcomeCutscenePart2 ();
			break;
		default:
			Debug.Log ("tu essai de jouer une cutscene qui est pas encore référencer ici");
			break;
		}
	}

	void PlayWelcomeCutscenePart1()
	{
		playableDirector.Play(welcomeCutscenePart1);
	}
	void PlayWelcomeCutscenePart2()
	{
		playableDirector.Play (welcomeCutscenePart2);

	}
	#endregion
}
