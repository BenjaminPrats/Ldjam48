using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class RangeAttack : Attack
{
	[SerializeField] private float _recoilStrength = 0.3f;
	[SerializeField] private float _recoilTime = 0.5f;

	[SerializeField] private bool _isDefense = false;

	// protected override void StartAttackAnim()
	// {
		
	// }

	protected override void StartReloadAnim()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.Append(_weaponPivot.DOLocalMoveZ(_recoilStrength, _recoilTime).SetEase(Ease.InFlash));
		sequence.Append(_weaponPivot.DOLocalMoveZ(0.0f, _reloadingTime - _recoilTime));
	}

	protected override void RotateTowards(Vector3 targetPosition)
	{
		base.RotateTowards(targetPosition);

		Quaternion targetRotation = Quaternion.LookRotation(targetPosition - _weaponPivot.position);
		Vector3 eulerTargetRotation = targetRotation.eulerAngles;
		eulerTargetRotation.y = 0f;
		eulerTargetRotation.z = 0f;
		targetRotation = Quaternion.Euler(eulerTargetRotation);
		_weaponPivot.rotation = Quaternion.RotateTowards(_weaponPivot.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
	}

	protected override int GetDamage()
	{
		int damage = base.GetDamage();
		if (_isDefense)
			damage += World.Instance.settings.defenseDamageModifier;
		else if (Side == Attackable.Side.Good)
			damage += World.Instance.settings.archerDamageModifier;
		return damage;
	}

	protected override float GetRange()
	{
		float range = base.GetRange();
		if (_isDefense)
			range *= World.Instance.settings.defenseRangeFactor;
		return range;
	}

}