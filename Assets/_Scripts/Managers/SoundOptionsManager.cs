using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundOptionsManager : MonoBehaviour 
{
	//Ce manager est très particulier.
	//Pour des raisons de continuité dans le son et autre, il doit être persistant !
	//c'est aussi utile qu'il soit un manager accessible de partout
	//pour pas que les liens avec son canvas se perdent en changeant de scene, il doit être poser sur son canvas 
	//contrairement a tous les autres manager, il est direct sur son canvas, j'insiste.

	public static SoundOptionsManager instance;
	public AudioMixer audioMix;

	public GameObject soundOptionsPanel; //Le panel a montré pour voir l'option de gestion de sons.
	public bool soundOptionsPanelOpen; //Le panel est il visible?

	public Sprite soundsOffImg;
	public Sprite musicOffImg;
	public Sprite soundsOnImg;
	public Sprite musicOnImg;

	public Image soundBtnImg;
	public Image musicBtnImg;

	AudioSource audioS;
	bool musicOn;
	bool soundsOn;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		} else 
		{
			Debug.Log ("on a 2 managers ici aussi");
			Destroy (gameObject);
		}
		audioS = GetComponent<AudioSource>();

	}

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt ("MUSIC", 1) == 1) 
		{
			musicOn = true;
		}
		if (PlayerPrefs.GetInt ("SOUNDS", 1) == 1) 
		{
			soundsOn = true;
		}
		ToggleMusic ();
		ToggleSoundEffects ();
	}


	public void ToggleMusic()
	{
		if (musicOn) 
		{
			audioMix.SetFloat("MainMusic",-20);
			PlayerPrefs.SetInt ("MUSIC", 1);
			musicBtnImg.sprite = musicOnImg;
		} else 
		{
			audioMix.SetFloat("MainMusic",-80);


			musicBtnImg.sprite = musicOffImg;

			PlayerPrefs.SetInt ("MUSIC", 0);

		}
		musicOn = !musicOn;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd);

	}

	public void ToggleSoundEffects()
	{
		if (soundsOn) 
		{
			audioMix.SetFloat ("EffectGroup", -15);
			soundBtnImg.sprite = soundsOnImg;
			PlayerPrefs.SetInt ("SOUNDS", 1);
		} else 
		{
			soundBtnImg.sprite = soundsOffImg;
			audioMix.SetFloat ("EffectGroup", -80);
			PlayerPrefs.SetInt ("SOUNDS", 0);
		}
		soundsOn = !soundsOn;
		audioS.PlayOneShot (SoundsManager.instance.soundsSO.validationSnd);

	}

	//Lié a un slider IG.
	public void SetGeneralVolume(float newVolumeLevel)
	{
		audioMix.SetFloat ("Master", newVolumeLevel);
	}

	public void ToggleSoundOptionsPanel()
	{
		if (soundOptionsPanelOpen) 
		{
			HideSoundOptionsPanel ();
		} else 
		{
			ShowSoundOptionsPanel ();
		}

	}

	public void ShowSoundOptionsPanel()
	{
		soundOptionsPanelOpen = true;
		soundOptionsPanel.SetActive (true);
	}

	public void HideSoundOptionsPanel()
	{
		soundOptionsPanelOpen = false;
		soundOptionsPanel.SetActive (false);
	}
}
