using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : IStateController
{
    [SerializeField] public Transform playerSpawn;
    [SerializeField] GameObject pawnPrefab;
    public int score = 0;


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

        Debug.Log("Score " + score);
        
    }

    public void OnEnable()
    {
        score = 0;
        Debug.Log("Starting Gameplay state");
        spawnPlayer();
        playerController.player.setDownBox += scoreIncrease;
        
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
        score += 1;
    }
}
