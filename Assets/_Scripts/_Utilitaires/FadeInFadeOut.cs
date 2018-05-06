using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class FadeInFadeOut : MonoBehaviour 
{
	//Quand le script s'active, provoque un écran de chargement fondu qui dure 2 sec de base.

	Image imageToFade;
	public Color loadingColor;

	void Awake () 
	{
		imageToFade = GetComponent<Image> ();	
	}

	void OnEnable()
	{
		StartCoroutine (FadeProcedure(2f));
	}


	IEnumerator FadeProcedure(float loadingTime)
	{
		Color c = loadingColor;
		c.a = 0f;
		imageToFade.color = c;

		while (imageToFade.color.a <.99f) 
		{
			c.a += .1f;
			imageToFade.color = c;
			yield return null;
		}

		yield return new WaitForSecondsRealtime (loadingTime);

		while (imageToFade.color.a >.025f) 
		{
			c.a -= .025f;
			imageToFade.color = c;
			yield return null;
		}

		gameObject.SetActive (false);

	}
}
