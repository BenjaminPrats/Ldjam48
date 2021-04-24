using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Observer pattern would be nice there but well, we are in jam :D
public class Attackable : MonoBehaviour
{
	bool _isAlive = true;

	public bool IsAlive { get => _isAlive; }
}
