using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : Singleton<World>
{
	List<Attackable> _goodAttackable = new List<Attackable>();
	List<Attackable> _evilAttackable = new List<Attackable>();

	bool _isDirty = true;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		UpdateList();
	}

	public void UpdateList()
	{
		if (!_isDirty)
			return;

		_goodAttackable = new List<Attackable>();
		_evilAttackable = new List<Attackable>();
		Attackable[] attackables = FindObjectsOfType<Attackable>();
		for (int i = 0; i < attackables.Length; i++)
		{
			if (attackables[i].IsGood)
			{
				_goodAttackable.Add(attackables[i]);
			}
			else if (attackables[i].IsEvil)
			{
				_evilAttackable.Add(attackables[i]);
			}
		}
		_isDirty = false;
	}

	public void AddAttackable(Attackable attackable)
	{
		// List<Attackable> list = GetOurList(attackable);
		// list.Add(attackable);
	}

	public void RemoveAttackable(Attackable attackable)
	{
		// List<Attackable> list = GetOurList(attackable);
		// list.Remove(attackable);
	}

	public Attackable FindNearestEnemy(Attackable attackable)
	{
		return FindNearestEnemy(attackable.GetSide(), attackable.transform.position);
	}

	public Attackable FindNearestEnemy(Attackable.Side ourSide, Vector3 ourPosition)
	{
		UpdateList();

		List<Attackable> enemies = ourSide == Attackable.Side.Good? _evilAttackable : _goodAttackable;
		Attackable nearest = null;
		float nearesDistanceSqr = float.MaxValue;
		for (int i = 0; i < enemies.Count; i++)
		{
			Attackable enemy = enemies[i];
			if (enemy == null)
			{
				Debug.LogWarning("Attackables lists not up to date");
				UpdateList();
				continue;
			}

			float distanceSqr = (ourPosition - enemy.transform.position).sqrMagnitude;
			if (distanceSqr > nearesDistanceSqr)
				continue;

			nearesDistanceSqr = distanceSqr;
			nearest = enemy;
		}

		return nearest;
	}

	private void LateUpdate()
	{
		_isDirty = true;
	}

	private List<Attackable> GetOurList(Attackable a)
	{
		return a.IsGood ? _goodAttackable : _evilAttackable;
	}

	private List<Attackable> GetEnemyList(Attackable a)
	{
		return a.IsEvil ? _goodAttackable : _evilAttackable;
	}
}
