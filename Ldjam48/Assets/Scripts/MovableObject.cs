using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
	[Range(0, 1)]
	[SerializeField] private float _tPath = 0.0f;
	[SerializeField] private float _tPathStart = 0.0f;

	[Header("Parameters")]
	[SerializeField] private float _speed = 1.0f;


	public void GoUp()
	{
		Move(-1.0f);
	}

	public void GoDown()
	{
		Move(1.0f);
	}

	private void Move(float direction) // direction should be 1 or -1
	{
		float pathLength = Tower.Instance.GetPathLength();
		_tPath += (direction * _speed * Time.deltaTime / pathLength);
		transform.position = Tower.Instance.GetPosition(_tPath);
	}
	private void Start()
	{
		_tPath = _tPathStart;
	}

	private void Update()
	{
		GoDown();
	}
}
