using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Singleton<Barracks>
{

	protected override void Awake()
	{
		base.Awake();
	}

	public enum Mode
	{
		S,
		A,
		SA
	}

	[SerializeField] Fighter _swordsman;
	[SerializeField] Fighter _archer;
	Mode _mode;

	Spawner _spawner;
	float _lastSpawnTime = 0.0f;
	
	private void Start()
	{
		_spawner = GetComponent<Spawner>();
		InitSpawner();
	}

	public void SetMode(Mode newMode)
	{
		_mode = newMode;
		InitSpawner();
	}

	private void InitSpawner()
	{
		_spawner.fighters = GetFighters();
		_spawner.isRandom = false;
	}

	private Fighter[] GetFighters()
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

	private void Update()
	{
		if ((Time.time - _lastSpawnTime) < World.Instance.barracksSpawnTime)
			return;

		_spawner.Spawn();
		_lastSpawnTime = Time.time;
	}
}
