using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
	[Range(0, 1)]
	[SerializeField] private float _tHelix = 0.0f;
	[SerializeField] private float _tHelixStart = 0.0f;

	private void Start()
	{
		_tHelix = _tHelixStart;
	}

	private void Update()
	{
		transform.position = Tower.Instance.GetPosition(_tHelix);
	}
}
