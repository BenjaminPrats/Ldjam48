using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MovableObject
{
	[SerializeField] private Attackable _attackable;
	[SerializeField] private BannerManager _bannerManager;
	[SerializeField] private Text _tutoText;
	[SerializeField] private GameObject _tutoPanel;

	protected override void Start()
	{
		base.Start();
		Move(0.0f); // Init position
	}

	private void Update()
	{
		if (!_attackable.IsAlive)
		{
			GameOver();
			return;
		}

		if (IsAtTop)
		{
			if (!_tutoPanel.activeSelf)
				ActiveTutoPanel();
		}
		else
		{
			if (_tutoPanel.activeSelf)
				_tutoPanel.SetActive(false);
		}


		if (_bannerManager.enabled)
		{
			return;
		}
		else if (IsAtTop)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
			{
				_bannerManager.enabled = true;
				_bannerManager.InitBanner();
				return;
			}
		}


		float verticalInput = Input.GetAxis("Vertical");

		_direction = verticalInput < 0.0f ? Tower.Direction.Down : Tower.Direction.Up;
		if (verticalInput != 0.0f)
			Move(Mathf.Abs(verticalInput));
	}

	public void ActiveTutoPanel()
	{
		_tutoPanel.SetActive(true);
		_tutoText.text = "Press 'E' or 'Left Arrow' to interact";
	}

	private void GameOver()
	{
		Debug.Log("You loose!");
	}
}
