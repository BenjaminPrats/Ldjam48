using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
	public enum State
	{
		None,
		Ready,
		Attacking,
		Reloading,
	}

	[SerializeField] Attackable.Side _side;
	[SerializeField] protected float _range = 1.0f;
	[SerializeField] protected int _attackDamage = 1;
	[SerializeField] protected float _reloadingTime = 1.0f;
	[SerializeField] protected float _attackTime = 0.5f;
	[SerializeField] protected Transform _weaponPivot;

	State _state = State.Ready;
	protected Attackable _target;
	float _actionTimer;

	public Attackable.Side Side => _side; 
	public bool IsReloading => _state == State.Reloading;
	public bool IsAttacking => _state == State.Attacking;
	public bool IsReady     => _state == State.Ready;

	// Return true if consume
	public bool HandleAction()
	{
		if (IsReloading || IsAttacking)
		{
			_actionTimer -= Time.deltaTime;
			if (_actionTimer > 0.0f)
				return true;

			// Action is finished, transition to next state
			if (IsAttacking)
			{
				_target.Hit(_attackDamage);
				_actionTimer = _reloadingTime;
				_state = State.Reloading;
			}
			else if (IsReloading)
			{
				StartReloadAnim();
				_state = State.Ready;
			}

			return true;
		}

		UpdateTarget();

		if (_target != null && IsReady)
		{
			StartAttackAnim();
			_state = State.Attacking;
			_actionTimer = _attackTime;
			return true;
		}

		return false;
	}

	protected virtual void StartAttackAnim()
	{

	}

	protected virtual void StartReloadAnim()
	{

	}

	protected void DoAttack()
	{
		
		_state = State.Reloading;
	}

	// To override with animation / delay and stuff
	protected virtual void LaunchAttack()
	{
		DoAttack();
	}

	private void UpdateTarget()
	{
		// Check if current target is still valid
		if (_target != null)
		{
			if (!IsValidTarget(_target))
				_target = null;
		}

		// Try to find a target if it doesn't have one
		if (_target == null)
		{
			Attackable nearestEnemy = HelperAttackable.FindNearestEnemy(_side, transform.position);
			if (nearestEnemy != null && IsValidTarget(nearestEnemy))
			{
				Debug.Log("Found target!");
				_target = nearestEnemy;
			}
		}
	}

	private bool IsValidTarget(Attackable target)
	{
		return target.IsAlive && (target.transform.position - transform.position).sqrMagnitude <= _range * _range;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, _range);
	}
}
