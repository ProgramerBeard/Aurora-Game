using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action {

	public enum SuperTypes
	{
		TARGET,
		SELF
	};

	public enum SubTypes
	{
		MAGICAL,
		PHYSICAL,
	};

	[Header ("Description")]
	public string name;
	public int idNumber;
	public SuperTypes superType;
	public SubTypes[] supTypes;

	[Header ("Damage")]
	public float baseHealthDamage;
	public float baseEnergyDamage;
	public float baseFocusDamage;

	[Header ("Cost")]
	public float baseHealthCost;
	public float baseEnergyCost;
	public float baseFocusCost;

	//Add the paraters
	public void ExeuteAction () {
		
	}
}