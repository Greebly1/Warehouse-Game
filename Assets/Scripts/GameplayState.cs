using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This functions similarly to a singleton, since the gamemanager is a singleton and it stores 1 reference to the gamestate
public class GameplayState : IStateController
{
    [SerializeField] public Transform playerSpawn;
    [SerializeField] GameObject pawnPrefab;
    [SerializeField] AudioClip startSound; // Sound to play on the start of gamepaly
    [SerializeField] AudioClip endSound; // Sound to play when the player loses
    bool firstTimeInGameplayState = true;

    int _score = 0;
    
    public int score //This property is used to automatically update the highscoree whenever the score changes
    {
        get { return _score; }
        set { 
            _score = value; 
            if (GameManager.Game.highscore < _score)
            {
                GameManager.Game.highscore = _score;
            }
        }
    }

    // Override from the IStateController Interface, this will be called by the gamemanager.SetState(newState) function
    public override void EndState()
    {
        Debug.Log("Ending Gameplay state");
        //When gameplay ends, the pawn needs to be destroyed,
        //all boxes must be destroyed,
        //all grids must be reset,
        //the ambience must be disabled,
        //and the endSound must be played

        Destroy(playerController.player.pawn); //Destroy pawn

        //Mark all boxes for destruction
        foreach (BoxPickup box in BoxPickup.boxes) { Destroy(box.gameObject); }

        //Tell all grid tiles to reset themselves
        foreach (GridItem item in GridItem.gridItems) { item.ResetSelf(); }

        //Disable the ambience
        playerController.player.ambience.enabled = false;

        //Play the end sound
        AudioSource.PlayClipAtPoint(endSound, playerController.player.pawn.gameObject.transform.position);

        Debug.Log("Score " + score);
        
    }

    //OnEnable is used for the start state functionality to automatically call when this state is enabled
    public void OnEnable() 
    {
        Debug.Log("Starting Gameplay state");
        //When the gameplay state starts
        //The score must be reset
        //The pawn must be spawned and assigned to the controller singleton
        //The startsound must be played

        
        score = 0;
        
        SpawnPlayer();
        playerController.player.setDownBox += ScoreIncrease;

        AudioSource.PlayClipAtPoint(startSound, playerController.player.pawn.gameObject.transform.position);
        playerController.player.ambience.enabled = true;

        if (!firstTimeInGameplayState) //This is a really brute force way of fixing this race condition
        {  
            //An error was being thrown becaue GridItem.Grid was not yet initialized
            //Now this block of code won't execute unless the game has already been initialized
            //This works ok, because the first box, and gridData is set in the scene serialization fields
            GridItem.Grid[2, 0].SpawnBox();
            GridItem.Grid[2, 0].containsPlayer = true;

            GridItem.Grid[2, 1].containsMonster = true;
        }
        firstTimeInGameplayState = true;
    }

    private void OnDisable()
    {
        playerController.player.setDownBox -= ScoreIncrease;
    }

    private void SpawnPlayer()
    {
        GameObject pawn = Instantiate(pawnPrefab, playerSpawn.position, playerSpawn.rotation);
        pawn.transform.parent = this.gameObject.transform;
        playerController.player.pawn = pawn;
    }

    void ScoreIncrease() // This function is meant to be bound to the setDownBox event within the playercontroller
    {
        score = score + 1;
    }

    public void GameOver() // This function ends the game from within the gameplay state, it's probably a useless abstraction though, since its only one line of code
    {
        GameManager.Game.SetState(gameState.Menu);
    }
}
