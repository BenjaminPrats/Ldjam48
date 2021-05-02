using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
	public OptionData data;

	Vector3 _startPosition;

	private void Awake()
	{
		_startPosition = transform.localPosition;
	}

	public void ResetPosition()
	{
		transform.localPosition = _startPosition;
	}

	public virtual bool TrySelect()
	{
		Select();
		return true;
	}

	public virtual int GetCost()
	{
		return 0;
	}

	protected virtual void Select()
	{
		Debug.Log(data.title + " is now selected.");
	}

	public virtual void Unselect()
	{
		Debug.Log(data.title + " is now unselected.");
	}
}
