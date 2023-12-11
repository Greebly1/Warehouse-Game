using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuState : IStateController
{
    public GameObject lostPrompt;
    public GameObject highScoreHolder;

    public override void endState()
    {
        Debug.Log("Ending Menu state");
    }

    public void OnEnable()
    {
        Debug.Log("Starting Menu state");
        if(GameManager.Game.stateLastIn == gameState.Gameplay) { lostPrompt.SetActive(true); }
        highScoreHolder.GetComponent<TextMeshProUGUI>().text = GameManager.Game.highscore.ToString();
        //Debug.Log("Score = " + GameManager.Game.highscore);
    }
}
