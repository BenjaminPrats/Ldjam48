using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class HelperAttackable
{
	static List<Attackable> _goodAttackable = new List<Attackable>();
	static List<Attackable> _evilAttackable = new List<Attackable>();


	static public void UpdateList()
	{
		_goodAttackable = new List<Attackable>();
		_evilAttackable = new List<Attackable>();
		Attackable[] attackables = Object.FindObjectsOfType<Attackable>();
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
	}

	static public void AddAttackable(Attackable attackable)
	{
		// List<Attackable> list = GetOurList(attackable);
		// list.Add(attackable);
	}

	static public void RemoveAttackable(Attackable attackable)
	{
		// List<Attackable> list = GetOurList(attackable);
		// list.Remove(attackable);
	}

	static public Attackable FindNearestEnemy(Attackable attackable)
	{
		return FindNearestEnemy(attackable.GetSide(), attackable.transform.position);
	}

	static public Attackable FindNearestEnemy(Attackable.Side ourSide, Vector3 ourPosition)
	{
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

	static private List<Attackable> GetOurList(Attackable a)
	{
		return a.IsGood ? _goodAttackable : _evilAttackable;
	}

	static private List<Attackable> GetEnemyList(Attackable a)
	{
		return a.IsEvil ? _goodAttackable : _evilAttackable;
	}
}