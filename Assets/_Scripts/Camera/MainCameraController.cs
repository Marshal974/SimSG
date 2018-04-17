using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {


	public Vector3 offset;

	private Transform playerTransformRef;
	// Use this for initialization
	void Start () {
		playerTransformRef = InGameManager.instance.playerObj.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localPosition = new Vector3 (playerTransformRef.position.x+offset.x, playerTransformRef.position.y+offset.y, playerTransformRef.position.z+offset.z);
	}
}
