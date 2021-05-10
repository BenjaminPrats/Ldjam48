using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
	[SerializeField] float _min = 13f;
	[SerializeField] float _max = 17f;

	Light _light;
	float _timer = 1f;

	private void Start()
	{
		_light = GetComponent<Light>();
	}

	private void Update()
	{
		_timer -= Time.deltaTime;
		if (_timer > 0f)
			return;

		_timer = Random.Range(0.5f, 1.2f);
		_light.intensity = Random.Range(_min, _max);
	}
	
}
