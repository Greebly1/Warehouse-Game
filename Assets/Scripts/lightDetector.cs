using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lightDetector : MonoBehaviour
{
    bool inLight = false;

    float timeSinceInLight = 0f; // timer variable keeps track of how long you've been in darkness
    //This timer variable is set to 0, when lighting conditions change

    [SerializeField] float shadowDeathTime = 8f; // how long you can be in the shadow before you die

    bool isInLight
    {
        get => GridItem.gridItems.Where(tile => tile.containsPlayer && tile._light.isOn).Count() > 0;
    }

    void OnEnable()
    {
        LightToggle.lightingUpdated += CheckLighting; 
        // lightingUpdated is a static event that invokes whenever any light is turned on or off
    }

    void OnDisable()
    {
        LightToggle.lightingUpdated -= CheckLighting;
    }

    //This should cover the framerate-independent points
    //Update will add deltatime to a timer and check if its time to kill the player
    private void Update()
    {
        if (inLight) { return; } //Early out, so we don't increment the timer unless we are in shadow

        timeSinceInLight += Time.deltaTime; //tick the timer


        if (timeSinceInLight >= shadowDeathTime)
        {
            if (GameManager.Game.state == gameState.Gameplay && !GameManager.Game.changingState)
            {
                //Debug.Log("DEATH!!!");
                GameManager.Game.gameplayState.GetComponent<GameplayState>().GameOver();
            }
        }
    }

    //This function is an event listener of the lightingChanged event, so it fires whenever a lightswitch toggles on or off
    void CheckLighting()
    {
        //The purpose is to check the lighting, I am using an event so that, it does not need to check every frame. It only needs to check whenever a light is turned on or off
        bool lightPoll = isInLight; //Cache a property call into a variable, this is true if the player is in light

        if (lightPoll == inLight) { return;  } //early out if we are in the light

        switch (isInLight)
        {
            case false: //player just entered shadow mode
                inLight = false;
                timeSinceInLight = 0; // reset shadow death timer
                Debug.Log("Player is in shadow");
                break;
            case true: //Player just entered light
                inLight = true;
                Debug.Log("player entered light");
                break;

        }
    }


}
