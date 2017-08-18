using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Effect", menuName = "Combat/Effect/Create New Effect")]
public class Effect : ScriptableObject {

	new public string name = "New Effect";
	public Sprite icon = null;
	public string description = "This is a description.";

	public float healthCost = 0;
	public float energyCost = 0;
	public float focusCost = 0;

	public float healthDamage = 0;
	public float energyDamage = 0;
	public float focusDamage = 0;

	public int durration = 1;

	// Needs one entity stats to effect.
	public virtual void ExecuteEffectAtStartOfTurn () {

	}

	// Needs one entity stats to effect.
	public virtual void ExecuteEffectAtEndOfTurn () {
		
	}
}