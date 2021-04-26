using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackableBuilding : Attackable
{
	[SerializeField] Transform _movingTransform;
	[SerializeField] float _deathOffset;
	[SerializeField] float _strengthTween = 0.4f;
	protected override void OnDeath()
	{
		base.OnDeath();
		_movingTransform.DOShakePosition(10f, _strengthTween * 0.5f);
		_movingTransform.DOShakeRotation(10f, _strengthTween * 0.3f);
		_movingTransform.DOShakeScale(10f, _strengthTween * 0.5f);
		_movingTransform.DOMoveY(_deathOffset, 10f);
		if (IsEvil)
		{
			World.Instance.HandleWin();
		}
	}

	protected override void OnHit(int damage)
	{
		base.OnHit(damage);
		_movingTransform.DOShakePosition(0.8f, _strengthTween);
	}

	
}
