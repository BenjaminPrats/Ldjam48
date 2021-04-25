using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryOption : Option
{
	[SerializeField] Barracks.Mode _mode;

	protected override void Select()
	{
		base.Select();
		Barracks.Instance.SetMode(_mode);
	}
}
