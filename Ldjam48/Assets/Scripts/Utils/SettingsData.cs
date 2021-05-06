using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsData", menuName = "")]
public class SettingsData : ScriptableObject
{
	[Header("Economy")]
	public float waitTimeCoinTick = 5f;
	public int coinPerTick = 1;
	public int coinPerKill = 5;

	public float optionCostFactor = 1f;

	[Space]
	[Header("Economy")]
	public float spawnTime = 5f;
	public int archerDamageModifier = 0;
	public int swordmenDamageModifier = 0;
	public int defenseDamageModifier = 0;
	public float defenseAttackSpeedFactor = 1f;
	public float defenseRangeFactor = 1f;

}