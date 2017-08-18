using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Action", menuName = "Combat/Action/Create New Action")]
public class Action : ScriptableObject {

	new public string name = "New Action";
	public Sprite icon = null;
	public string description = "This is a description.";

	public float healthCost = 0;
	public float energyCost = 0;
	public float focusCost = 0;

	public float healthDamage = 0;
	public float energyDamage = 0;
	public float focusDamage = 0;

	// Needs two entity stats to have an action on.
	public virtual void ExecuteAction () {
	
	}
}