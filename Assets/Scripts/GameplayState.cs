using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : IStateController
{
    public override void endState()
    {
        Debug.Log("Ending Gameplay state");
    }

    public void OnEnable()
    {
        Debug.Log("Starting Gameplay state");
    }
}
