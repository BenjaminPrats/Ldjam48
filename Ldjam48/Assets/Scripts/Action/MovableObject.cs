using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour // Attackable
{
	[Range(0, 1)]
	[SerializeField] private float _tPath = 0.0f;
	[SerializeField] private float _tPathStart = 0.0f;

	[Header("Parameters")]
	[SerializeField] protected Tower.Direction _direction;
	[SerializeField] protected float _speed = 1.0f;
	[SerializeField] protected float _rotationSpeed = 100.0f;

	Tower.Direction Direction { get => _direction; set => _direction = value; }

	public void Move()
	{
		float direction = _direction == Tower.Direction.Down ? 1.0f : -1.0f; 

		// Position
		float pathLength = Tower.Instance.GetPathLength();
		_tPath += (direction * _speed * Time.deltaTime / pathLength);

		// Rotation
		transform.position = Tower.Instance.GetPosition(_tPath);
		if (_tPath > 0.999f || _tPath < 0.001f) // keep the previous rotation
			return;

		float tStep = _tPath + 0.05f;
		Vector3 targetPosition = Tower.Instance.GetPosition(_tPath + 0.05f);
		RotateTowards(targetPosition);
	}

	protected virtual void Start()
	{
		_tPath = _tPathStart;
	}

	private void RotateTowards(Vector3 targetPosition)
	{
		Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
	}

}