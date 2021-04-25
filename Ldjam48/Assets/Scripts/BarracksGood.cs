using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksGood : Barracks
{
	public float spawnTime = 10.0f;
	public enum Mode
	{
		S,
		A,
		SA
	}

	[SerializeField] protected Fighter _swordsman;
	[SerializeField] protected Fighter _archer;
	Mode _mode;

	public void SetMode(Mode newMode)
	{
		_mode = newMode;
		InitSpawner();
	}

	protected override void Start()
	{
		base.Start();
	}

	protected override Fighter[] GetFighters()
	{
		Fighter[] fighters = new Fighter[0];
		switch (_mode)
		{
			case Mode.S:
				fighters = new Fighter[1];
				fighters[0] = _swordsman;
				break;
			case Mode.A:
				fighters = new Fighter[1];
				fighters[0] = _archer;
				break;
			case Mode.SA:
				fighters = new Fighter[2];
				fighters[0] = _swordsman;
				fighters[1] = _archer;
				break;
		}
		return fighters;
	}

	protected override float GetSpawnTime()
	{
		return spawnTime;
	}

}
