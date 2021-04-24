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

		int stepCount = _cycleCount * _stepCountPerCycle;
		float step = 1.0f / ((float)(stepCount - 1));
		_steps = new Transform[stepCount];

		for (int i = 0; i < stepCount; i++)
		{
			_steps[i] = Instantiate(_stepTransform, transform);

			float tHelix = step * (float)i;
			_steps[i].localPosition = _helix.GetPosition(tHelix);

			float angle = Mathf.Rad2Deg * _helix.GetAngleRad(tHelix);
			_steps[i].localRotation = Quaternion.Euler(0.0f, -angle, 0.0f);
		}
	}

	public Vector3 GetStartPosition()
	{
		if (_steps == null || _steps.Length < 1)
		{
			Debug.LogError("No valid Stairs");
			return Vector3.zero;
		}
		return _steps[0].position;
	}

	public Vector3 GetEndPosition()
	{
		if (_steps == null || _steps.Length < 1)
		{
			Debug.LogError("No valid Stairs");
			return Vector3.zero;
		}
		return _steps[_steps.Length - 1].position;
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
