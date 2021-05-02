using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerManager : MonoBehaviour
{
	[SerializeField] public float _highlightOffset;
	[SerializeField] private Text _tutoText;
	[SerializeField] private Text _barracksText;
	[SerializeField] private GameObject _barrackPanel;
	Banner[] _banners = new Banner[3];
	int _oldIndex = 0;
	int _currentIndex = 0;

	bool _inBanner = false;

	public void InitBanner()
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
		_tutoText.text = "Press Left/Right Arrow to choose \r\nPress 'E' or 'Lower Arrow' to select\r\nPress Esc or go a all the way right to Exit";
	}

	public void UpdateHighlightedBanner()
	{
		_barrackPanel.SetActive(true);

		Debug.Log("Current Active Banner: " + _currentIndex);
		_banners[_oldIndex].ResetPosition();
		_banners[_currentIndex].transform.Translate( Vector3.forward * _highlightOffset);
		_oldIndex = _currentIndex;

		BannerData bannerData = _banners[_currentIndex].data;
		_barracksText.text = bannerData.title+ "\r\n" + bannerData.description; 
	}

	private void Start()
	{
		InitBanner();
	}

	private void ToggleFocus()
	{
		_inBanner = !_inBanner;
		if (_inBanner)
		{
			_tutoText.text = "Press Left/Right Arrow to choose \r\nPress 'E' or 'Lower Arrow' to select\r\nPress Esc or go a all the way right to Exit";
		}
		else
		{
			_tutoText.text =  "Press Left/Right Arrow to choose \r\nPress 'E' or 'Lower Arrow' to Buy/Activate \r\nEsc or Up arrow to Exit";
		}
	}

	void PrintOptionData(Option option)
	{
		OptionData data = option.data;
		_barracksText.text = data.title+ "\r\n" + data.description + "\r\nCost: " + option.GetCost(); 
	}

	private void Update()
	{
		if (_inBanner)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				Option option = _banners[_currentIndex].GoNext(1);
				PrintOptionData(option);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				Option option = _banners[_currentIndex].GoNext(-1);
				PrintOptionData(option);
			}
			else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (_banners[_currentIndex].TrySelectOption())
				{ // Succeed
					_banners[_currentIndex].SelectExit();
					ToggleFocus();
				}
				else
				{ // Failed
					Debug.Log("Can't buy");
				}
			}
			else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				_banners[_currentIndex].SelectExit();
				ToggleFocus();
			}
		}
		else
		{
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
			else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				ToggleFocus();
				_banners[_currentIndex].SelectEnter();
			}
		}

	}

	private void ExitBanners()
	{
		_barrackPanel.SetActive(false);
		_tutoText.text = "Press 'E' or 'Left Arrow' to interact";
		_banners[_currentIndex].ResetPosition();
		this.enabled = false;
	}
}
