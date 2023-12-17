using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This title state controller does nothing, because, you never enter title state, you just start in it
//nothing special need to happen when the state ends either
//perhaps this is where music should go
public class TitleState : IStateController
{

    public override void EndState() //ovverride from the IStateController
    {
        Debug.Log("Ending Title state");
    }

    public void OnEnable()
    {
        Debug.Log("Starting Title state");
    }
}
