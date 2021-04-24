using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class StairsGenerator : MonoBehaviour
{
	[SerializeField] private Transform _stepTransform;
	[SerializeField] private Helix _helix;

	[Header("Parameters")]
	[SerializeField] private float _radius;
	[SerializeField] private float _height;
	[SerializeField] private int _cycleCount = 3;
	[SerializeField] private int _stepCountPerCycle;

	[Space]
	[SerializeField] private bool _update = false;

	private Transform[] _steps;

	public void GenerateStairs()
	{
		Init();
		DeleteStairs();
		const float twoPI = Mathf.PI * 2.0f;
		float endAngle = twoPI * (float)_cycleCount;
		float angleStep = twoPI / (float)_stepCountPerCycle;
		float heightStep = _height / (twoPI * (float)_cycleCount);

		int stepCount = (int)((float)_cycleCount * (float)_stepCountPerCycle * angleStep);
		_steps = new Transform[stepCount];

		for (int i = 0; i < stepCount; i++)
		{
			float currentAngle = angleStep * i;
			_steps[i] = Instantiate(_stepTransform, transform);
			_steps[i].localPosition = new Vector3(_radius * Mathf.Cos(currentAngle), -heightStep * currentAngle, _radius * Mathf.Sin(currentAngle));
		}

	}

	private void Update()
	{
		if (!_update)
			return;
		GenerateStairs();
	}

	private void Start()
	{
		_radius = _helix.radius;
		_height = _helix.height;
		_cycleCount = _helix.cycleCount;
	}

	private void OnValidate()
	{
		_helix.cycleCount = _cycleCount;
		_helix.radius = _radius;
		_helix.height = _height;
	}

	private void Init()
	{
		int stepsCount = transform.childCount;
		_steps = new Transform[stepsCount];
		for (int i = 0; i < stepsCount; i++)
			_steps[i] = transform.GetChild(i).transform;
	}

	private void DeleteStairs()
	{
		if (_steps == null)
			return;

		for (int i = _steps.Length - 1; i >= 0; i--)
		{
			DestroyImmediate(_steps[i].gameObject);
		}

	}
}
