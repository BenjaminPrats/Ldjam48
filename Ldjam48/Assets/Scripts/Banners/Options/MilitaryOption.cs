using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryOption : Option
{
	[SerializeField] BarracksGood.Mode _mode;

	protected override void Select()
	{
		base.Select();
		World.Instance.BarracksGood.SetMode(_mode);
	}
}
