using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuState : IStateController
{
    public GameObject lostPrompt; //text object telling the playr they died
    public GameObject highScoreHolder; //text object holding the highscore

    public override void EndState() //override from the IStateController interface, which is actually an abstract class that was originally an interface
    {
        Debug.Log("Ending Menu state");//This one doesn't do anything though, ending the menustate has no complex logic
    }

    //When the menustate begins it needs to update the highscore text
    public void OnEnable()
    {
        Debug.Log("Starting Menu state");
        if(GameManager.Game.stateLastIn == gameState.Gameplay) { lostPrompt.SetActive(true); } //<-- it will also enable the lostPrompt text if it came from the gameplay gamestate
        highScoreHolder.GetComponent<TextMeshProUGUI>().text = GameManager.Game.highscore.ToString();
        //Debug.Log("Score = " + GameManager.Game.highscore);
    }
}
