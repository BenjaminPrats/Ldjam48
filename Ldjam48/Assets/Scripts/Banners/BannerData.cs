using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BannerData", menuName = "")]
public class BannerData : ScriptableObject
{
	public string title = "Banner";
	[Multiline(4)] public string description = "";
	
}
