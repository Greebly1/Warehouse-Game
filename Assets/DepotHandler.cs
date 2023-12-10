using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepotHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        pickupReceiver player = other.GetComponent<pickupReceiver>();
        if (player == null) { return; } //early out

        if(playerController.player.isHoldingBox)
        {
            playerController.player.setDownBox.Invoke();
        }
    }
}
