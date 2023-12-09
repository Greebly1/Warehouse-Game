using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IStateController
{

    public override void endState()
    {
        Debug.Log("Ending Menu state");
    }

    public void OnEnable()
    {
        Debug.Log("Starting Menu state");
    }
}
