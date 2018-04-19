using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour 
{
	//on gère ici l'appel de sons pour le jeu.
	//on peut imaginer aussi plus tard, gérer un peu mieux la superposition des sons
	//il vient compléter l'audiomixer /l'audio master dans le meilleur des cas.

	public static SoundsManager instance;

	[Tooltip("Contient tous les sons du jeu pour référencement.")]
	public SoundLibrarySO soundsSO;

	#region MonoB functions

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("Two Managers here!");
			Destroy (gameObject);
		}
	}

	void Start()
	{
		GetComponent<AudioSource> ().PlayOneShot (soundsSO.MainMusic);
	}
	#endregion

}
