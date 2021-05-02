using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseOption : Option
{
	[SerializeField] GameObject[] _defenseObjects;

	static public int nextDefenseId = 0;

	protected override void Select()
	{
		base.Select();
		_defenseObjects[nextDefenseId].SetActive(true);
		nextDefenseId++;
	}

	public override bool TrySelect()
	{
		if (nextDefenseId < _defenseObjects.Length)
		{

			if (World.Instance.TryBuy(data.cost * nextDefenseId))
			{
				return base.TrySelect();
			}
			else
			{
				Debug.Log("Not enough money!");
			}
		}
		else
		{
			Debug.LogWarning("Unexpected, should not be able to ask for more defense.");
		}
		return false;
	}

	public override int GetCost()
	{
		return data.cost * (1 + nextDefenseId); // The price increase after each buy
	}
}
