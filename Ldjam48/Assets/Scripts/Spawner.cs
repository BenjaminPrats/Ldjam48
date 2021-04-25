using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Fighter _fighterPrefab;
	[SerializeField] private Transform _startPosition;
	[SerializeField] private float _startT;

	public bool isRandom = true;

	public Fighter[] fighters;
	
	int _previousId = 0;

	public void Spawn()
	{
		if (fighters.Length < 1)
			return;

		int i = isRandom ? Random.Range(0, fighters.Length) : (_previousId + 1) % fighters.Length;
		_previousId = i;
		Fighter fighter = fighters[i];
		
		Fighter newFighter = Instantiate(fighter, transform.position, transform.rotation);
		newFighter.StartAt(_startPosition.position);
	}
}
