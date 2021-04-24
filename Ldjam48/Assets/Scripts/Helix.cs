using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Helix", menuName = "")]
public class Helix : ScriptableObject
{
	[Range(0.1f, 10.0f)] public float radius = 1.0f;
	[Range(1.0f, 100.0f)] public float height = 10.0f;
	[Range(1, 100)] public int cycleCount = 3;

	public const float twoPI = Mathf.PI * 2.0f;

	// t has to be between 0 and 1
	public Vector3 GetPosition(float t)
	{
		float heightStep = height / (twoPI * (float)cycleCount);

		float currentAngle = GetAngleRad(t);

		return new Vector3(radius * Mathf.Cos(currentAngle), -heightStep * currentAngle, radius * Mathf.Sin(currentAngle));
	}

	public float GetAngleRad(float t)
	{
		return t * twoPI * (float)cycleCount;
	}

	public float GetLength()
	{
		float heightPerCycle = height / (float)cycleCount;
		float perimeterCircle = twoPI * radius;
		float lengthPerCycle = Mathf.Sqrt(heightPerCycle * heightPerCycle + perimeterCircle * perimeterCircle);
		return lengthPerCycle * (float)cycleCount;
	}
}
