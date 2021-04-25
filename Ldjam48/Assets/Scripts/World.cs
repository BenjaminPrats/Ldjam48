using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : Singleton<World>
{
	public float moverYOffset;
	[Header("Coins Param")]
	[SerializeField] int _coins;
	[SerializeField] float _waitTimeForCoin = 2.0f;
	[SerializeField] int _coinPerTick = 1;

	float _coinTimer;

	protected override void Awake()
	{
		base.Awake();
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
		_coins += _coinPerTick;
	}
}
