using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksEvil : Barracks
{
	[SerializeField] protected Fighter _swordsman;
	[SerializeField] protected Fighter _archer;
	[SerializeField] protected Fighter _bigGuy;

	public float spawnTimeMin = 5.0f;
	public float spawnTimeMax = 10.0f;
	public float bigGuyTime = 120.0f;

	protected override void Start()
	{
		base.Start();
	}

	protected override Fighter[] GetFighters()
	{
		Fighter[] fighters = new Fighter[0];
		if (Time.time > bigGuyTime)
		{
			fighters = new Fighter[8];
			fighters[0] = _swordsman;
			fighters[1] = _swordsman;
			fighters[2] = _swordsman;
			fighters[3] = _swordsman;
			fighters[4] = _archer;
			fighters[5] = _archer;
			fighters[6] = _archer;
			fighters[7] = _bigGuy;
		}
		else
		{
			fighters = new Fighter[2];
			fighters[0] = _swordsman;
			fighters[1] = _archer;
		}

		return fighters;
	}

	protected override float GetSpawnTime()
	{
		return Random.Range(spawnTimeMin, spawnTimeMax);
	}
}
