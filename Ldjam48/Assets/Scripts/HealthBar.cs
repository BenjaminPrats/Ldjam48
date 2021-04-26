using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] RectTransform _transform;
	[SerializeField] Transform _camera;
	private float _maxHealth;
	private float _currentHealth;

	public void Init(float maxHealth)
	{
		_maxHealth = maxHealth;
		SetNewHealth(maxHealth);
	}

	public void SetNewHealth(float newHealth)
	{
		_currentHealth = Mathf.Clamp(newHealth, 0.0f, _maxHealth);
		_transform.localScale = new Vector3(_currentHealth / _maxHealth, 1, 1);
	}

	private void LateUpdate()
	{
		transform.LookAt(World.Instance.Camera.transform.position);
	}
}
