using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] PlayerController _player;

	private void Update()
	{
		Vector3 position = transform.position;
		position.y = _player.transform.position.y; 
		transform.position = position;
	}
}
