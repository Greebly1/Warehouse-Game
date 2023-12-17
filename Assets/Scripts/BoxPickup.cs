using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxPickup : MonoBehaviour, IPickup
{
    [SerializeField] AudioClip PickupSound;

    public static List<BoxPickup> boxes = new List<BoxPickup>(); // List of referencs to all boxes, used to keep track of how many boxes there are, and to loop through all boxes

    //Pickup Logic
    void OnTriggerEnter(Collider other)
    {
        pickupReceiver receiver = other.GetComponent<pickupReceiver>();
        if (receiver == null)
        {
            return; //Early out
        }
        //the following code will be executed when a pickup is picked up
        pickupReceiver.pickedUpItem.Invoke();

        Destroy(this.gameObject);
    }

    private void Awake()
    {
        boxes.Add(this); // Add this box to the list of all the boxes
    }

    //Spawn a box at a random tile that doesn't contain a player, a monster, or another box.
    public static void SpawnRandomBox()
    {
        //Create a list of applicable grid squares
        //An applicable gridsquare doeas not contain the player, a box, or a monster
        List<GridItem> applicableSquares = GridItem.gridItems.Where(square => !square.containsBox && !square.containsPlayer && !square.containsMonster).ToList();

        //Generate a random index within the range of the applicable square list
        int randomIndex = Random.Range(0, applicableSquares.Count);
        
        //access that random gridItem and tell it to spawn a box
        applicableSquares[randomIndex].SpawnBox();

    }

    private void OnDestroy()
    {
        // this line of code is meant to play the pickup sound only if the game is not ending
        if (!GameManager.Game.changingState) { AudioSource.PlayClipAtPoint(PickupSound, transform.position); } 
        
        // Makes sure to remove this box from the list of all boxes
        boxes.Remove(this);
    }

}
