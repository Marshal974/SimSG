using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour {

	//Ce script référencie et gère les achievements unlock et lock.
	//il contient une liste des achievements a afficher dans la liste des locks en début de partie.
	//il contient 2 listes de "achievementSO" : une pour les complétés, une pour les non complétés.
	//il travail en coopération avec le achievementsUI  qui peut bien evidemment être trouver sur le moduleUImanager qui contient une référence a chaque UI script du module 
	//au début du jeu, il fait spawn les différents achievements (plus tard c'est la qu'on mettra le chargement and co)
	//on peut faire appel a lui pour ajouter un nouvel achievement dans la liste des locks
	//on peut aussi faire appel a lui pour déplacer un élément de lock vers unlock.
	//il utilise le systeme d'alerte du jeu pour indiquer au joueur qu'un achievement a été déverrouiller.

	public static AchievementsManager instance;

	[Header("Place ici les achievements du module:")]
	[Tooltip("mettre ici tous les achievementsSO qu'on veut voir visible dés le début.")]
	public List<AchievementSO> allAchievementsList; //a noté que ya une fonction pour rajouter un achievement Ingame en plein milieu du jeu hein. Pas obligé de tout montrer au joueur direct hein.

	public List<AchievementSO> unlockedAchievementsList = new List<AchievementSO>();
	public List<AchievementSO> lockedAchievementsList = new List<AchievementSO>();

	public Dictionary <AchievementSO, GameObject> allAchievementsDico = new Dictionary<AchievementSO, GameObject> (); //un dico contenant tous les achievements et leur ui item associé.

	public GameObject achievementUIPrefab;

	public Transform unlockedAchievementsScrollView; //Ca sert surtout de référence pour savoir ou spawn les trucs. A compléter soit meme pour le moment.
	public Transform lockedAchievementsScrollView;

	public int globalAchievementScore;

	#region monoB
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("On a 2 achievements manager humain.");
			Destroy (gameObject);
		}
	}

	void Start()
	{
		foreach (var item in allAchievementsList) {
			AddNewAchievement (item);
		}

	}

	#endregion

	#region fonctions principales
	//permet d'ajouter un nouveau achievement.
	//on fait spawn le UI associé, on le met ou il faut, on l'ajoute au dictionnaire avec son ASO associé.
	public void AddNewAchievement(AchievementSO ASO)
	{

		//voir plus tard pour le lock / unlocked, pour le moment tout est locked de base.
		GameObject go = Instantiate (achievementUIPrefab);
		go.transform.SetParent (lockedAchievementsScrollView.transform);
		go.transform.position = Vector3.zero;
		go.transform.localScale = Vector3.one;

		AchievementItem AItem;
		AItem = go.GetComponent<AchievementItem> ();
		if (ASO.achievementVisual) 
		{
			AItem.visualToShow = ASO.achievementVisual;
		}
		AItem.InitializeAchievementUI (ASO.achievementName, ASO.achievementDesc, ASO.achievementScore);
		//on ajoute le tout au dico.
		allAchievementsDico.Add (ASO, go);

		//on l'ajoute aussi a la liste des locked.
		lockedAchievementsList.Add (ASO);
	}

	//permet d'unlock un achievement présent dans le dico.
	public void UnlockAchievement(AchievementSO unlockedASO)
	{
		GameObject Go; 

		lockedAchievementsList.Remove (unlockedASO);
		unlockedAchievementsList.Add (unlockedASO);
		allAchievementsDico.TryGetValue (unlockedASO, out Go);
		Go.transform.SetParent (unlockedAchievementsScrollView);
		Go.transform.position = Vector3.zero;
		Go.transform.localScale = Vector3.one;
		globalAchievementScore += Go.GetComponent<AchievementItem> ().achievementScore;
		Go.GetComponent<AchievementItem> ().achievementIsLocked = false;
		ModuleUIManager.instance.achievementsUI.achievementGlobalScoreTxt.text = globalAchievementScore.ToString ();

		//rajouter ici tout autre action a faire sur l'objet en question, comme par exemple des modifs esthétiques

		AlertMessageManager.instance.CreateAnAlert ("Bravo: '" + Go.GetComponent<AchievementItem> ().achievementName + "' Dévérouiller!", 1);
	}
	#endregion

	#region utilitaires
	public bool CheckIfAchievementIsLocked(AchievementSO theASO)
	{
		if (lockedAchievementsList.Contains (theASO)) 
		{
			return true;
		}
		return false;
	}

	#endregion

}

