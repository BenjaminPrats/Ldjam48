using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner : MonoBehaviour
{

	public BannerData data;
	Vector3 _startPosition;
	Option[] _options;
	int _currentIndex = 0;
	int _oldIndex = 0;

	private void Awake()
	{
		_startPosition = transform.localPosition;
		_options = transform.GetComponentsInChildren<Option>();
		Debug.Log("Found " + _options.Length + "options");
	}

	public void ResetPosition()
	{
		transform.localPosition = _startPosition;
	}

	private void UpdateHighlightedOption()
	{
		_options[_oldIndex].ResetPosition();
		_options[_currentIndex].transform.Translate( Vector3.forward * World.Instance.bannerOffset);
		_oldIndex = _currentIndex;
	}

	public void GoNext(int sign = 1)
	{
		_currentIndex = (_currentIndex + sign) % _options.Length;
		UpdateHighlightedOption();
	}

	public virtual void SelectEnter()
	{
		UpdateHighlightedOption();
	}

	public bool TrySelectOption()
	{
		return _options[_currentIndex].TrySelect();
	}

	public virtual void SelectExit()
	{
		for (int i = 0; i < _options.Length; i++)
			_options[i].ResetPosition();
	}
	
}
