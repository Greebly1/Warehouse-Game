using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The pickupreceiver is a component that goes on the pawn 
public class pickupReceiver : MonoBehaviour
{
    //A lot of things observe this event, such as the UI
    public static Action pickedUpItem = delegate { }; //static event

    public void Pickup(IPickup pickup) 
    {
        pickedUpItem.Invoke();
        Debug.Log("PICKUP");
    }
}
