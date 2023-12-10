using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : IStateController
{
    [SerializeField] public Transform playerSpawn;
    [SerializeField] GameObject pawnPrefab;

    public override void endState()
    {
        Debug.Log("Ending Gameplay state");
    }

    public void OnEnable()
    {
        Debug.Log("Starting Gameplay state");
        spawnPlayer();
    }

    private void spawnPlayer()
    {
        GameObject pawn = Instantiate(pawnPrefab, playerSpawn.position, playerSpawn.rotation);
        pawn.transform.parent = this.gameObject.transform;
        playerController.player.pawn = pawn;
    }
}
