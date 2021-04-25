using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionData", menuName = "")]
public class OptionData : ScriptableObject
{
	public string title = "";
	[Multiline(4)] public string description = "";
	public int cost = 0;
}
