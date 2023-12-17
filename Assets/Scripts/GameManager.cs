using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState
{
    Title,
    Menu,
    Gameplay
}


public class GameManager : MonoBehaviour
{
    public static GameManager Game; // Singleton
    public gameState state;
    public gameState stateLastIn = gameState.Title; // This is used to not, display the You Died message on the first time of entering the menu state

    //Enable and disable these to simulate levels changing
    public IStateController titleState;
    public IStateController menuState;
    public IStateController gameplayState;

    public int highscore = 0; // Automatically set from within the gameplayState

    //This is meant to be used during state changes to ensure certain things don't happen while the state is ending
    public bool changingState { get; private set; } = false; 

    private void Awake() // Singleton Logic
    {
        if(GameManager.Game == null)
        {
            GameManager.Game = this;
        } else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SetState(gameState.Title); 
    }

    private void Update()
    {
        //These were used for debugging, to easily swich game states
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setState(gameState.Title);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setState(gameState.Menu);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setState(gameState.Gameplay);
        } */
    }

    //Use to set the state of the game, this function calls the necessary endstate and beginstate functions
    //Returns a boolean for whether the state was successfully set or not
    public bool SetState(gameState newState)
    {
        if ( state != newState)
        {
            changingState = true;
            

            switch (state) // Switch statement handles calling the endstate functions
            {
                case gameState.Title:
                    titleState.EndState();
                    break;

                case gameState.Menu:
                    menuState.EndState();
                    break;

                case gameState.Gameplay:
                    gameplayState.EndState();
                    break;
            }

            changingState = false;
            stateLastIn = state;
            state = newState; //Set the new state
            DisableAllStates(); // Disable all the states (so that the previous state is also disabled)

            switch (state) //Switch statement handles enabling the current state, and switching the player's input mode
            {
                case gameState.Title:
                    titleState.gameObject.SetActive(true);
                    playerController.player.input.SwitchCurrentActionMap("title");
                    break;

                case gameState.Menu:
                    menuState.gameObject.SetActive(true);
                    playerController.player.input.SwitchCurrentActionMap("menu");
                    break;

                case gameState.Gameplay:
                    gameplayState.gameObject.SetActive(true);
                    playerController.player.input.SwitchCurrentActionMap("gamePlay");
                    break;
            }
            return true;
        }

        return false;
    }

    void DisableAllStates()
    {
        titleState.gameObject.SetActive(false);
        menuState.gameObject.SetActive(false);
        gameplayState.gameObject.SetActive(false);
    }
}

