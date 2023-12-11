using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxPickup : MonoBehaviour, IPickup
{
    public static List<BoxPickup> boxes = new List<BoxPickup>();
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
        boxes.Add(this);
    }

    public static void spawnRandomBox()
    {
        //Create a list of applicable grid squares
        //An applicable gridsquare doeas not contain the player, a box, or a monster
        List<GridItem> applicableSquares = GridItem.gridItems.Where(square => !square.containsBox && !square.containsPlayer && !square.containsMonster).ToList();

        //Generate a random index within the range of the applicable square list
        int randomIndex = Random.Range(0, applicableSquares.Count);
        
        //access that random gridItem and tell it to spawn a box
        applicableSquares[randomIndex].spawnBox();

    }

    private void OnDestroy()
    {
        boxes.Remove(this);
    }

}
