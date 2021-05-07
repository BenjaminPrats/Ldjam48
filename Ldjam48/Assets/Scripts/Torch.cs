using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
	[SerializeField] Light _light;

	private void OnTriggerStay(Collider other)
	{
		Debug.Log("Detected");
		PlayerController player = other.gameObject.GetComponent<PlayerController>();
		if (player)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				Light();
				// Call player animation
			}
		}
	}

	private void Light()
	{
		// Do the actual lighting and deactivate the script
		_light.gameObject.SetActive(true);
		this.enabled = false;
	}

}
