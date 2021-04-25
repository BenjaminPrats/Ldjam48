using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovableObject
{
	[SerializeField] private Attackable _attackable;

	protected override void Start()
	{
		base.Start();
		Move(0.0f); // Init position
	}

	private void Update()
	{
		if (!_attackable.IsAlive)
		{
			GameOver();
			return;
		}
		float verticalInput = Input.GetAxis("Vertical");

		_direction = verticalInput < 0.0f ? Tower.Direction.Down : Tower.Direction.Up;
		if (verticalInput != 0.0f)
			Move(Mathf.Abs(verticalInput));
	}

	private void GameOver()
	{
		Debug.Log("You loose!");
	}
}
