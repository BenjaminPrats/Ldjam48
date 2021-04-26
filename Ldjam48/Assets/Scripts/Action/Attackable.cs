using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attackable : MonoBehaviour
{
	public enum Side
	{
			Good,
			Evil
	}

	[SerializeField] protected int  _maxHealth = 10;
	[SerializeField] protected Side _side;

	protected int _currentHealth;
	protected bool _isActive = true;
	protected HealthBar _healthBar;

	public bool IsAlive { get => _currentHealth > 0 && _isActive; }
	public bool IsGood  { get => _side == Side.Good; }
	public bool IsEvil  { get => _side == Side.Evil; }

	public bool IsEnemy(Attackable att) { return _side != att._side; }
	public Side GetSide() => _side;

	protected virtual void Awake()
	{
		_currentHealth = _maxHealth;
	}

	public virtual bool Hit(int damage)
	{
		if (!IsAlive)
			return false;

		_currentHealth -= damage;
		OnHit(damage);

		if (!IsAlive)
		{
			OnDeath();
			return true;
		}
		return true;
	}

	protected virtual void OnHit(int damage)
	{
		if (_healthBar == null)
		{
			_healthBar = Instantiate(World.Instance.GetHealthBarPrefab(_side), transform);
			_healthBar.Init(_maxHealth);
		}

		_healthBar.SetNewHealth(_currentHealth);

		Debug.Log("Receive " + damage + " damage");
	}

	protected virtual void OnDeath()
	{
		HelperAttackable.RemoveAttackable(this);
		Debug.Log("Die!");
	}
}
