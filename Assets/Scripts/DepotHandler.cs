using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DepotHandler : MonoBehaviour
{
    [SerializeField] AudioClip setDownSound;
    [SerializeField] Transform soundLocation;

    private void OnTriggerEnter(Collider other)
    {
        pickupReceiver player = other.GetComponent<pickupReceiver>();
        if (player == null) { return; } //early out

        if(playerController.player.isHoldingBox)
        {
            playerController.player.setDownBox.Invoke();
            AudioSource.PlayClipAtPoint(setDownSound, soundLocation.position);


            BoxPickup.spawnRandomBox();

            //Amazingly disgutsing line of code, it kills all monsters, then spawns a number of monsters based on the current score
            //This works because killAllMonsters and spawnMonsters both return the monster manager 
            Monster.Manager.killAllMonsters().spawnMonsters(GameManager.Game.gameplayState.GetComponent<GameplayState>().score);
            
        }
    }

    
}
