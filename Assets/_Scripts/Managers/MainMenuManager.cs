using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


[RequireComponent(typeof(AudioSource))]
public class MainMenuManager : MonoBehaviour 
{

	//Ce script gère le menu principale c'est a dire:
	//L'affichage des élements du menu (panel etc)
	//Les fonctions relative au menu.
	//Les sons et tout le tintoin...

	[Header("Référencement de tous les panels du menu principale.")]

	public GameObject mainMenuPanel;
    public GameObject OptionsPanel;
	public GameObject modulesPanel; // il contiendra que finance pour le moment hélas ^^ mais on peut mettre du fake!!!
	public GameObject nicknameSelecPanel;
	public GameObject moreInfoPanel;
	public GameObject welcomePanel; //On le montre a un joueur qui a jamais lancé le jeu. lié a un bouton "dont show again";
	public GameObject logInPanel;
	public GameObject serialNumberPanel;

	[Header("Les boutons et objets dont on doit avoir connaissance:")]

	public Button connectButton; //on en a besoin pour savoir si il faut le rendre interactif ou pas (pour plus tard) : check connection internet par exemple!
	public GameObject pressEnterObj; //l'objet texte de départ : "cliquez pour commencer"

	#region private variables

	AudioSource effectsAudioS; //L'audioS pour les retours utilisateur sur appui touche.
	bool hasTouchedOrClicked; //T'as appuyer qqpart déja ? que jtaffiche le menu.
	int dontShowAgain; //un bool pour savoir si le joueur a coché le "don't show again" du welcomepanel plus haut.
	int firstTimePlaying; //C'est la première fois que le jeu est lancé (un faux bool)

	//pour ce qui est du système de login:
	string clientID;
	string clientPassword;

	#endregion

	#region monoB paradise

	private void Awake()
	{
		//on configure certaines variables
		effectsAudioS = GetComponent<AudioSource>();

		//on check ici si c'est la première fois que tu joues, et on agit en fonction.
		firstTimePlaying =  PlayerPrefs.GetInt ("FIRST_TIME_PLAYING", 0);
		if (firstTimePlaying == 0) 
		{
			FirstTimePlayingProcedure ();
			PlayerPrefs.SetInt ("FIRST_TIME_PLAYING", 1);

		}

		//check ou création du "show welcome panel" bool
		dontShowAgain = PlayerPrefs.GetInt ("SHOW_WELCOME_PANEL", 0);
	}
	public void Update ()
	{
		if (!hasTouchedOrClicked) 
		{
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return) || Input.GetMouseButtonDown(0)) 
			{
				ShowMainMenu ();
				hasTouchedOrClicked = true;
				pressEnterObj.SetActive (false);

				//On check si tu veux/dois voir le welcomePanel
				if(dontShowAgain == 0)
				{
					ShowWelcomePanel ();
				}
			}
		}
	}

	#endregion

	#region Main panel functions

	//Il suffit d'appeler cette fonction pour revenir au panel principal.
	public void ShowMainMenu()
	{
		HideAllMenuPanels ();
		mainMenuPanel.SetActive (true);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);

	}
		
    public void showOption()
    {
		OptionsPanel.SetActive(!OptionsPanel.activeSelf);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);

    }

	public void showModuleSelectionPanel()
	{
		HideAllMenuPanels ();
		modulesPanel.SetActive(true);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);
	}

	public void ShowHelpPanel()
	{
		HideAllMenuPanels ();
		moreInfoPanel.SetActive (true);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);

	}
	public void ShowLogInPanel()
	{
		HideAllMenuPanels ();
		logInPanel.SetActive (true);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);

	}

	public void ShowSerialNumberPanel()
	{
		HideAllMenuPanels ();
		serialNumberPanel.SetActive (true);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);

	}

	void ShowWelcomePanel()
	{
		HideAllMenuPanels ();
		welcomePanel.SetActive (true);
	}

	//Cette fonction n'est pas utilisé pour le moment:
	void ShowNicknameSelectionPanel()
	{
		HideAllMenuPanels ();
		nicknameSelecPanel.SetActive (true);
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);
		
	}

	//utilitaires:

	public void HideAllMenuPanels()
	{
		mainMenuPanel.SetActive (false);
		OptionsPanel.SetActive (false);
		modulesPanel.SetActive (false);
		moreInfoPanel.SetActive (false);
		nicknameSelecPanel.SetActive (false);
		welcomePanel.SetActive (false);
		logInPanel.SetActive (false);
		serialNumberPanel.SetActive (false);
		SoundOptionsManager.instance.HideSoundOptionsPanel ();

	}

	public void QuitGame()
	{
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.validationSnd);

		Application.Quit ();
	}

	public void StartNewGame()
	{
		PlayerPrefs.SetString("GAME", "new");
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.successSnd);
		Invoke("LoadSpecificScene",.8f);
	}


	public void ContinueGame()
	{
		PlayerPrefs.SetString("GAME", "continue");
		effectsAudioS.PlayOneShot(SoundsManager.instance.soundsSO.successSnd);

		Invoke("LoadSpecificScene",.8f);
	}

	//nécessaire pour les invokes plus haut, si on met un param c'est cuit, va falloir encapsuler tout ca
	//en temps voulu.
	void LoadSpecificScene()
	{
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}

	#endregion

	#region Select your nickname

	void FirstTimePlayingProcedure()
	{
		//On a pas parler de ca encore. A corriger a l'occase voir ce qu'on veut faire de plus que de montrer le welcome panel.
		//		ShowNicknameSelectionPanel ();

	}

	//appeler depuis UI
	public void ChangeYourNickname(string newNickname)
	{
		
		ShowMainMenu ();
		PlayerPrefs.SetString ("NICKNAME", newNickname);
	}

	#endregion

	#region WelcomePanel

	//appelé depuis UI
	public void DontShowWelcomePanelAgain(bool hidePanel)
	{
		if (hidePanel) 
		{
			PlayerPrefs.SetInt ("SHOW_WELCOME_PANEL", 1);
			ShowMainMenu ();
		} else 
		{
			PlayerPrefs.SetInt ("SHOW_WELCOME_PANEL", 0);
		}
	}


	#endregion

	#region Client connection to account

	public void ChangeClientIDField(string newID)
	{
		clientID = newID;	
	}

	public void ChangeClientPasswordField(string newPassword)
	{
		clientPassword = newPassword;
	}

	//Appelé depuis UI (le bouton connection)
	public void TryToConnectToAccount()
	{
		//Return toujours true pour le moment:
		if (CheckClientConnectionInfo (clientID, clientPassword)) 
		{
			showModuleSelectionPanel();
			logInPanel.SetActive (false);
		}
	}

	//La fonction qui permet de vérifié si les infos données par le joueur
	//pour se connecter sont corrects!
	bool CheckClientConnectionInfo(string ID, string pass)
	{
		//Pour le moment je return donc toujours true ^^
		return true;
	}

	#endregion

}
