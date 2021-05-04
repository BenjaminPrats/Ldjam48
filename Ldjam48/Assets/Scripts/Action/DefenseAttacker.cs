using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAttacker : MonoBehaviour
{
	RangeAttack _attack;

	private void Start()
	{
		_attack = GetComponent<RangeAttack>();
	}
	private void Update()
	{
		_attack.HandleAction();
	}
}
