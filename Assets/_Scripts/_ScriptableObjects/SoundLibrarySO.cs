using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "SimangoSG/SoundLibrary", order = 1)]
public class SoundLibrarySO : ScriptableObject 
{
	//ce SO a pour mission de contenir tous les sons récurrents du jeu.
	//on peut, en le remplacant, changer directement tous les sons du jeu ^^ merveilleux oui oui.

	public AudioClip MainMusic;
	public AudioClip validationSnd;
	public AudioClip errorSnd;
	public AudioClip successSnd;


}
