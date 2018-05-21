using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementItem", menuName = "SimangoSG/Achievement", order = 3)]

public class AchievementSO : ScriptableObject 
{
	public string achievementName; //son nom
	public string achievementDesc; //sa description
	public Sprite achievementVisual; //son visuel associé si besoin
	public int achievementScore; //le nombre de point que donne l'achievement.
}
