using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Singleton<Tower>
{
	[SerializeField] private Helix _helix;

	protected override void Awake()
	{
		base.Awake();
	}

	public Vector3 GetPosition(float t)
	{
		Vector3 localPosition = _helix.GetPosition(t);
		return transform.TransformPoint(localPosition);
	}
}
