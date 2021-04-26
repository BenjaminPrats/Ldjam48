using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackableMovable : Attackable
{
	[SerializeField] Transform _parent;
	protected override void OnDeath()
	{
		base.OnDeath();
		_parent.gameObject.SetActive(false);
	}

	protected override void OnHit(int damage)
	{
		base.OnHit(damage);
		_parent.DOShakePosition(0.8f, 0.1f);
	}

}
