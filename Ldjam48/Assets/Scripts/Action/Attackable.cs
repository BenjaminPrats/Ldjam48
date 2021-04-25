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
		if (!IsAlive)
		{
			OnDeath();
			return true;
		}

		OnHit(damage);
		return true;
	}

	protected virtual void OnHit(int damage)
	{
		Debug.Log("Receive " + damage + " damage");
	}

	public virtual void OnDeath()
	{
		HelperAttackable.RemoveAttackable(this);
		Debug.Log("Die!");
	}
}
