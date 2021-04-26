using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MeleeAttack : Attack
{

	protected override void StartAttackAnim()
	{
		_weaponPivot.transform.DOLocalRotate(new Vector3(120.0f, 0, 0), _attackTime);

	}

	protected override void StartReloadAnim()
	{
		_weaponPivot.transform.DOLocalRotate(new Vector3(0.0f, 0, 0), _reloadingTime);
	}

}
