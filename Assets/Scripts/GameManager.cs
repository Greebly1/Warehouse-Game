using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Game;
    public gameState state;
    public IStateController titleState;
    public IStateController menuState;
    public IStateController gameplayState;

    private void Awake()
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
        setState(gameState.Title);
    }

    private void Update()
    {
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
        }
    }

    //Use to set the state of the game, this function calls the necessary endstate and beginstate functions
    //Returns a boolean for whether the state was successfully set or not
    public bool setState(gameState newState)
    {
        if ( state != newState)
        {
            switch (state)
            {
                case gameState.Title:
                    titleState.endState();
                    break;

                case gameState.Menu:
                    menuState.endState();
                    break;

                case gameState.Gameplay:
                    gameplayState.endState();
                    break;
            }

            state = newState;
            disableAllStates();

            switch (state)
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

    private void disableAllStates()
    {
        titleState.gameObject.SetActive(false);
        menuState.gameObject.SetActive(false);
        gameplayState.gameObject.SetActive(false);
    }
}

public enum gameState
{
    Title,
    Menu,
    Gameplay
}
