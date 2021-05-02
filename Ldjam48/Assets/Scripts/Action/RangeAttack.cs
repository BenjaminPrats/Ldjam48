using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class RangeAttack : Attack
{
	[SerializeField] private float _recoilStrength = 0.3f;
	[SerializeField] private float _recoilTime = 0.5f;

	// protected override void StartAttackAnim()
	// {
		
	// }

	protected override void StartReloadAnim()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.Append(_weaponPivot.DOLocalMoveZ(_recoilStrength, _recoilTime).SetEase(Ease.InFlash));
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

}