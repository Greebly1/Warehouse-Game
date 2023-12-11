using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : IStateController
{
    [SerializeField] public Transform playerSpawn;
    [SerializeField] GameObject pawnPrefab;
    [SerializeField] AudioClip startSound;
    [SerializeField] AudioClip endSound;

    int _score = 0;
    
    public int score
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


    public override void endState()
    {
        Debug.Log("Ending Gameplay state");
        Destroy(playerController.player.pawn);

        foreach (BoxPickup box in BoxPickup.boxes)
        {
            Destroy(box.gameObject);
        }

        foreach (GridItem item in GridItem.gridItems)
        {
            item.resetSelf();
        }

        playerController.player.ambience.enabled = false;

        AudioSource.PlayClipAtPoint(endSound, playerController.player.pawn.gameObject.transform.position);

        Debug.Log("Score " + score);
        
    }

    public void OnEnable()
    {
        score = 0;
        Debug.Log("Starting Gameplay state");
        spawnPlayer();
        playerController.player.setDownBox += scoreIncrease;

        AudioSource.PlayClipAtPoint(startSound, playerController.player.pawn.gameObject.transform.position);
        playerController.player.ambience.enabled = true;

        GridItem.Grid[2, 0].spawnBox();
        GridItem.Grid[2, 0].containsPlayer = true;

        GridItem.Grid[2,1].containsMonster = true;

        
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        playerController.player.setDownBox -= scoreIncrease;
    }

    private void spawnPlayer()
    {
        GameObject pawn = Instantiate(pawnPrefab, playerSpawn.position, playerSpawn.rotation);
        pawn.transform.parent = this.gameObject.transform;
        playerController.player.pawn = pawn;
    }

    void scoreIncrease()
    {
        score = score + 1;
    }

    public void gameOver()
    {
        GameManager.Game.setState(gameState.Menu);
    }
}
