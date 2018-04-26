using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Glossary : MonoBehaviour 
{

	public void OpenGlossary()
	{
		ModuleUIManager.instance.helpUI.OpenInGameHelpPanel ();
	}
		
}
