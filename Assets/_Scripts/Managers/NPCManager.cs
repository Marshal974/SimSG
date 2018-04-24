using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour 
{
	public static NPCManager instance;
	public List<GameObject> allActiveNPC = new List<GameObject>();
	public List<NPCPatrolRoad> allPatrolRoads = new List<NPCPatrolRoad>();

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
