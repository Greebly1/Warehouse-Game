using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : IStateController
{

    public override void endState()
    {
        Debug.Log("Ending Title state");
    }

    public void OnEnable()
    {
        Debug.Log("Starting Title state");
    }
}
