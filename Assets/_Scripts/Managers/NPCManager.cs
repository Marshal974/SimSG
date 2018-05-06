using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour 
{

	//ce manager sert a garder trace des pnj important (et autres plus tard).

	public static NPCManager instance;
	public List<GameObject> allActiveNPC = new List<GameObject>();
	public List<NPCPatrolRoad> allPatrolRoads = new List<NPCPatrolRoad>();

	public GameObject secretaryNPC;
	public GameObject directorNPC;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		} else 
		{
			Debug.Log ("il y a 2 npc managers!");
			Destroy (gameObject);
		}
	}
}
