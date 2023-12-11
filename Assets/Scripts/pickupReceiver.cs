using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupReceiver : MonoBehaviour
{
    public static Action pickedUpItem = delegate { };

    public void pickup(IPickup pickup) 
    {
        pickedUpItem.Invoke();
        Debug.Log("PICKUP");
    }
}
