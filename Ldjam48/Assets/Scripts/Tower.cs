using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Singleton<Tower>
{
	[SerializeField] private Helix _helix;
	[SerializeField] private Transform _start;
	[SerializeField] private Transform _end;

	private float _startPathLength;
	private float _endPathLength;
	private float _helixLength;
	private float _pathLength;

	private float _ratioStartStairs;
	private float _ratioEndStairs;


	public float GetPathLength() { return _pathLength; }

	public Vector3 GetPosition(float t)
	{
		if (t < 0.0f)
			return _start.position;
		if (t > 1.0f)
			return _end.position;

		float tPath = 0.0f;
		if (t < _ratioStartStairs)
		{ // Start
			tPath = t / _ratioStartStairs;
			return Vector3.Lerp(_start.position, GetStairsPosition(0.0f), tPath);
		}
		else if (t < _ratioEndStairs)
		{ // Stairs
			tPath = (t - _ratioStartStairs) / (_ratioEndStairs - _ratioStartStairs);
			return GetStairsPosition(tPath);
		}

		// End
		tPath = (t - _ratioEndStairs) / (1.0f - _ratioEndStairs);
		return Vector3.Lerp(_start.position, GetStairsPosition(0.0f), tPath);
	}

	protected override void Awake()
	{
		base.Awake();
		_startPathLength = GetStartPathLength();
		_endPathLength   = GetEndPathLength();
		_helixLength     = _helix.GetLength();
		_pathLength      = _startPathLength + _endPathLength + _helixLength;

		_ratioStartStairs = _startPathLength / _pathLength;
		_ratioEndStairs   = _ratioStartStairs + (_helixLength / _pathLength);
	}
	private float GetStartPathLength()
	{
		return (_start.position - GetStairsPosition(0.0f)).magnitude;
	}

	private float GetEndPathLength()
	{
		return (_end.position   - GetStairsPosition(1.0f)).magnitude;
	}

	private Vector3 GetStairsPosition(float t)
	{
		Vector3 localPosition = _helix.GetPosition(t);
		return transform.TransformPoint(localPosition);
	}

}
