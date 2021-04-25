using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Fighter _fighterPrefab;
	[SerializeField] private Transform _startPosition;
	[SerializeField] private float _startT;

	private float nextSpawn = 0.0f; 

	public void Spawn(Fighter fighter)
	{
		Fighter newFighter = Instantiate(fighter, transform.position, transform.rotation);
		newFighter.StartAt(_startPosition.position);
	}

	private void Update()
	{
		if (Time.time < nextSpawn)
			return;

		Spawn(_fighterPrefab);
		nextSpawn = Time.time + 10.0f;
	}
}
