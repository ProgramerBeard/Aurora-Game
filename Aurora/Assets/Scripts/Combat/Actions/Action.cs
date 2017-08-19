using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Combat/Action/Create New Action")]
public class Action : ScriptableObject
{

    public enum SuperTypes
    {
        PHYSCIAL,
        MAGICAL,
        SUPPORT
    };

    public enum SubTypes
    {
        NORAML,
        FIRE,
        ICE,
        EARTH,
        BLACK,
        WHITE
    };

    [Header("Description")]
    new public string name = "New Action";

    public SuperTypes[] superType;
    public SubTypes[] subType;

    [Space(10)]
    public Sprite icon = null;
    [Space(10)]

    [TextArea(3, 10)] public string description = "This is a description.";

    [Header("Gameplay")]
    public float healthCost = 0;
    public float energyCost = 0;
    public float focusCost = 0;
    public float healthDamage = 0;
    public float energyDamage = 0;
    public float focusDamage = 0;

    // Needs two entity stats to have an action on.
    public virtual void ExecuteAction()
    {
	
    }
}