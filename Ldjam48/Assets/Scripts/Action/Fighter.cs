using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MovableObject
{
	public enum State
	{
		None,
		Active,
	}

	[SerializeField] private Attackable _attackable;
	[SerializeField] private Attack _attacker;
	[Header("Fighter Properties")]

	State _state = State.None;


	public void StartAt(Vector3 startingPoint)
	{
		StartCoroutine(MoveToStartingPoint(startingPoint));
		
	}

	protected override void Start()
	{
		base.Start();
		_state = State.None;

		if (_attackable == null || _attacker == null || _attackable.GetSide() != _attacker.Side)
			Debug.LogError("Invalid attackable / attacker");
		_attackable.enabled = false;
	}

	private void Update()
	{
		if (!_attackable.IsAlive)
			return;

		if (_state == State.None)
			return;

		if (_attacker.HandleAction())
			return; // attacker consumed the action

		Move();
	}


	IEnumerator MoveToStartingPoint(Vector3 startingPoint)
	{
		while ((startingPoint - transform.position).sqrMagnitude > 0.01f)
		{
			Vector3 direction = (startingPoint - transform.position).normalized;
			transform.position = transform.position + direction * _speed * Time.deltaTime;
			yield return null;
		}

		_attackable.enabled = true;
		HelperAttackable.AddAttackable(_attackable);
		_state = State.Active;
	}
}
