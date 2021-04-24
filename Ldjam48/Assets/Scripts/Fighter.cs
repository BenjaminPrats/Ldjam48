using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MovableObject
{
	public enum State
	{
		None,
		Move,
		Attack,
	}

	[Header("Fighter Properties")]
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _attackRadius;


	State _state = State.None;
	float _currentHealth;
	Transform _target;


	public void StartAt(Vector3 startingPoint)
	{
		StartCoroutine(MoveToStartingPoint(startingPoint));
	}

	protected override void Start()
	{
		base.Start();
		_currentHealth = _maxHealth;
		_state = State.None;
	}

	private void Update()
	{
		if (_state == State.None)
			return;

		if (_target == null)
		{
			// Check if there is any near enemy
			

			Move();
			return;
		}



		if (_state == State.Attack)
		{
			// Attack
		}
		else if (_state == State.Move)
		{
			Move();
		}
	}


	IEnumerator MoveToStartingPoint(Vector3 startingPoint)
	{
		while ((startingPoint - transform.position).sqrMagnitude > 0.01f)
		{
			Vector3 direction = (startingPoint - transform.position).normalized;
			transform.position = transform.position + direction * _speed * Time.deltaTime;
			yield return null;
		}

		_state = State.Move;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, _attackRadius);
	}
}
