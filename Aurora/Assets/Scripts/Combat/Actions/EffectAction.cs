using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Combat/Action/Create New Effect Action")]
public class EffectAction : Action {

    public Effect effectToAdd;

    public override void ExecuteAction()
    {
        base.ExecuteAction();
    }
}