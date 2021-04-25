using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : Singleton<World>
{
	public float moverYOffset;
	public float bannerOffset = 0.3f;
	[Header("Coins Param")]
	[SerializeField] int _coins;
	[SerializeField] float _waitTimeForCoin = 2.0f;
	[SerializeField] int _coinPerTick = 1;

	[Header("Spawn Param")]
	public float barracksSpawnTime = 10.0f;
	float enemySpawnTime = 10.0f;

	float _coinTimer;
	int Coins
	{
		get => _coins;
		set
		{
			_coins = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}

	public bool TryBuy(int cost)
	{
		if (cost > Coins)
			return false;

		Coins -= cost;
		return true;
	}

	private void Start()
	{
		HelperAttackable.UpdateList();
		_coinTimer = _waitTimeForCoin;
	}

	private void Update()
	{
		CoinTick();
	}

	private void LateUpdate()
	{
		HelperAttackable.UpdateList();
	}

	private void CoinTick()
	{
		_coinTimer -= Time.deltaTime;
		if (_coinTimer > 0.0f)
			return;

		_coinTimer = _waitTimeForCoin;
		Coins += _coinPerTick;
	}
}
