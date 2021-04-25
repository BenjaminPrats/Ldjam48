using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerManager : MonoBehaviour
{
	[SerializeField] private float _highlightOffset;
	Banner[] _banners = new Banner[3];
	int _oldIndex = 0;
	int _currentIndex = 0;

	bool _inBanner = false;

	public void UpdateHighlightedBanner()
	{
		Debug.Log("Current Active Banner: " + _currentIndex);
		_banners[_oldIndex].ResetPosition();
		_banners[_currentIndex].transform.Translate( Vector3.forward * _highlightOffset);
		_oldIndex = _currentIndex;
	}

	private void Start()
	{
		if (transform.childCount != 3)
		{
			Debug.LogError("Invalid Banners");
			return;
		}

		for (int i = 0; i < 3; i++)
		{
			_banners[i] = transform.GetChild(i).GetComponent<Banner>();
		}

		_oldIndex = 0;
		_currentIndex = 0;
		UpdateHighlightedBanner();
	}

	private void Update()
	{
		if (_inBanner)
			return; // TODO


		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			_currentIndex++;
			if (_currentIndex >= _banners.Length)
				_currentIndex = _banners.Length - 1;

			UpdateHighlightedBanner();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			_currentIndex--;
			if (_currentIndex < 0)
			{
				_currentIndex = 0;
				ExitBanners();
				return;
			}

			UpdateHighlightedBanner();
		}
		else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
		{
			_inBanner = true;
			_banners[_currentIndex].SelectEnter();
		}
	}

	private void ExitBanners()
	{
		_banners[_currentIndex].ResetPosition();
		this.enabled = false;
	}
}
