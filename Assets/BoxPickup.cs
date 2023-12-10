using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickup : MonoBehaviour, IPickup
{

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
    
}
