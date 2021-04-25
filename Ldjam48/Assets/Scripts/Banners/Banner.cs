using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner : MonoBehaviour
{
	Vector3 _startPosition;

	private void Awake()
	{
		_startPosition = transform.localPosition;
	}

	public void ResetPosition()
	{
		transform.localPosition = _startPosition;
	}

	public virtual void SelectEnter()
	{

	}
	public virtual void SelectExit()
	{

	}
	
}
