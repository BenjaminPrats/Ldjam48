using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StairsGenerator))]
public class StairsGeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		StairsGenerator script = (StairsGenerator)target;
		if (GUILayout.Button("Generate"))
		{
			script.GenerateStairs();
		}
	}
}
