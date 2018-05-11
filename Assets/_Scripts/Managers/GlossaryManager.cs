using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryManager : MonoBehaviour {

	public static GlossaryManager instance;

	public List<GlossaryItemSO> allEntries = new List<GlossaryItemSO>();

	public GameObject glossaryItemPrefab;

	public Transform glossaryContentView;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Debug.Log ("On a 2 glossary manager jeune homme/femme.");
			Destroy (gameObject);
		}
	}

	void Start()
	{
		InitializeTheGlossary ();
	}

	void InitializeTheGlossary()
	{
		foreach (var entry in allEntries) 
		{
			GameObject go = GameObject.Instantiate (glossaryItemPrefab);
			go.transform.SetParent (glossaryContentView);
			go.transform.localScale = Vector3.one;

			go.GetComponent<GlossaryItem> ().InitializeTheEntryInGlossary (entry.entryName, entry.entryDefContent);
			if (entry.visualToDisplay != null) 
			{
				go.GetComponent<GlossaryItem> ().visualToShow = entry.visualToDisplay;
			}
		}
	}

	public void ShowSpecificEntry(string entryTitle, string entryFullDef)
	{
		ModuleUIManager.instance.helpUI.mainEntryVisualImage.enabled = false; //jusqu'a preuve du contraire en dessous XD
		ModuleUIManager.instance.helpUI.mainEntryNameTxt.text = entryTitle;
		ModuleUIManager.instance.helpUI.mainEntryDefinitionTxt.text = entryFullDef;
	}

	public void ShowSpecificEntryVisual(Sprite visual)
	{
		ModuleUIManager.instance.helpUI.mainEntryVisualImage.sprite = visual;
		ModuleUIManager.instance.helpUI.mainEntryVisualImage.enabled = true;
		ModuleUIManager.instance.helpUI.mainEntryVisualImage.SetNativeSize ();
	}
}
