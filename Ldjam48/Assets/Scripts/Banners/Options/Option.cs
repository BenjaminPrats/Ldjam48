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

	public bool TrySelect()
	{
		if (World.Instance.TryBuy(data.cost))
		{
			Select();
			return true;
		}

		return false;
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
