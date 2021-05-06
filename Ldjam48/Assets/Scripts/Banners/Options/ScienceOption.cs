using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceOption : Option
{
	public delegate void UpgradeN();

	protected int _currentUpgradeId = 0;
	protected UpgradeN[] _upgrades;
	static int _globalScienceOptionCost = 0;

	protected virtual void Start()
	{
		_upgrades = new UpgradeN[]{
		new UpgradeN(Upgrade0),
		new UpgradeN(Upgrade1),
		new UpgradeN(Upgrade2)
		};
	}

	protected override void Select()
	{
		base.Select();
		_upgrades[_currentUpgradeId]();
		_currentUpgradeId++;
		_globalScienceOptionCost++;
	}

	protected virtual void Upgrade0()
	{

	}

	protected virtual void Upgrade1()
	{

	}

	protected virtual void Upgrade2()
	{

	}

	public override bool IsValid()
	{
		return _currentUpgradeId < 3;
	}

	public override int GetCost()
	{
		return (int)((float)data.cost * (1f + (float)_globalScienceOptionCost) * World.Instance.settings.optionCostFactor); // The price increase after each buy
	}
}
