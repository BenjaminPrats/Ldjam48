using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class World : Singleton<World>
{
	[SerializeField] SettingsData _startingSettings;
	[HideInInspector] public SettingsData settings;
	public float moverYOffset;
	public float bannerOffset = 0.3f;
	[Header("Coins Param")]
	[SerializeField] int _coins;

	[Space]
	[SerializeField] BarracksGood _barracksGood;

	[Space]
	[SerializeField] HealthBar _goodHealthBar;
	[SerializeField] HealthBar _evilHealthBar;
	[SerializeField] Camera _camera;

	[Space]
	[SerializeField] Text _moneyText;

	public HealthBar GetHealthBarPrefab(Attackable.Side side) { return side == Attackable.Side.Evil ? _evilHealthBar : _goodHealthBar; }

	public Camera Camera => _camera;
	public BarracksGood BarracksGood { get => _barracksGood; }

	float _coinTimer;
	public int Coins
	{
		get => _coins;
		set
		{
			_coins = value;
			_moneyText.text = _coins.ToString();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		settings = Instantiate(_startingSettings);
	}

	public bool TryBuy(int cost)
	{
		if (cost > Coins)
			return false;

		Coins -= cost;
		return true;
	}

	public void HandleWin()
	{
		Debug.Log("You win!");
	}


	private void Start()
	{
		HelperAttackable.UpdateList();
		_coinTimer = settings.waitTimeCoinTick;
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

		_coinTimer = settings.waitTimeCoinTick;
		Coins += settings.coinPerTick;
	}


}
