using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Effect", menuName = "Combat/Effect/Create New Effect")]
public class Effect : ScriptableObject {

	public enum SuperTypes
	{
		PHYSCIAL, MAGICAL
	};

	public enum SubTypes
	{
		NORAML, FIRE, ICE, EARTH, BLACK, WHITE
	};

	[Header ("Description")]
	new public string name = "New Effect";
	public SuperTypes[] superType;
	public SubTypes[] subType;

	[Space (10)]
	public Sprite icon = null;
	[Space (10)]

	[TextArea (3, 10)]public string description = "This is a description.";

	[Header ("Gameplay")]
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