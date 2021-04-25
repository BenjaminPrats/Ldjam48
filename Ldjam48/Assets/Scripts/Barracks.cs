using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barracks : Singleton<Barracks>
{
	[SerializeField] protected bool _isRandom = true;
	protected override void Awake()
	{
		base.Awake();
	}

	protected Spawner _spawner;
	float _lastSpawnTime = 0.0f;
	
	protected virtual void Start()
	{
		_spawner = GetComponent<Spawner>();
		InitSpawner();
	}

	protected void InitSpawner()
	{
		_spawner.fighters = GetFighters();
		_spawner.isRandom = _isRandom;
	}

	protected virtual Fighter[] GetFighters()
	{
		Fighter[] fighters = new Fighter[0];
		return fighters;
	}

	protected virtual float GetSpawnTime()
	{
		return 10.0f;
	}

	private void Update()
	{
		if ((Time.time - _lastSpawnTime) < GetSpawnTime())
			return;

		_spawner.Spawn();
		_lastSpawnTime = Time.time;
	}
}
