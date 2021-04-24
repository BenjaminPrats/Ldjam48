using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class Fighter : MovableObject
{
	public enum State
	{
		None,
		Active,
	}

	[Header("Fighter Properties")]

	State _state = State.None;
	Attack _attacker;


	public void StartAt(Vector3 startingPoint)
	{
		_isActive = false;
		StartCoroutine(MoveToStartingPoint(startingPoint));
	}

	protected override void Start()
	{
		base.Start();
		_state = State.None;
		_attacker = GetComponent<Attack>();
	}

	private void Update()
	{
		if (!IsAlive)
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

		_isActive = true;
		_state = State.Active;
	}
}
