using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DepotHandler : MonoBehaviour
{
    [SerializeField] AudioClip setDownSound;
    [SerializeField] Transform soundLocation;

    /// <summary>
    /// The only thing a depot needs to do is allow the player to deposit a box if they are holding one
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != playerController.player.pawn.gameObject) { return; } //early out if the colliding object is not the player


        if(playerController.player.isHoldingBox)
        {
            //The player has now deposited a box the following follows though with doing this

            playerController.player.setDownBox.Invoke(); // Send out the signal that the box has been set down
            AudioSource.PlayClipAtPoint(setDownSound, soundLocation.position);


            BoxPickup.SpawnRandomBox(); // Spawn a random box to become the new box the player must pick up

            //Amazingly disgutsing line of code, it kills all monsters, then spawns a number of monsters based on the current score
            //This works because killAllMonsters and spawnMonsters both return the monster manager 
            Monster.Manager.KillAllMonsters().SpawnMonsters(GameManager.Game.gameplayState.GetComponent<GameplayState>().score);
            
        }
    }

    
}
