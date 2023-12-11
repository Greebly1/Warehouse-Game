using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lightDetector : MonoBehaviour
{
    bool inLight = false;

    float timeSinceInLight = 0f;
    [SerializeField] float shadowDeathTime = 8f;

    private void OnEnable()
    {
        LightToggle.lightingUpdated += checkLighting;
    }

    private void OnDisable()
    {
        LightToggle.lightingUpdated -= checkLighting;
    }

    private void Update()
    {
        if (inLight) { return; } //Early out

        timeSinceInLight += Time.deltaTime;

        if (timeSinceInLight >= shadowDeathTime)
        {
            if (GameManager.Game.state == gameState.Gameplay && !GameManager.Game.changingState)
            {
                Debug.Log("DEATH!!!");
                GameManager.Game.gameplayState.GetComponent<GameplayState>().gameOver();
            }
        }
    }

    void checkLighting()
    {
        bool lightPoll = isInLight();

        if (lightPoll == inLight) { return;  }

        switch (isInLight())
        {
            case false:
                inLight = false;
                timeSinceInLight = 0;
                Debug.Log("Player is in shadow");
                break;
            case true:
                inLight = true;
                Debug.Log("player entered light");
                break;

        }
    }

    bool isInLight()
    {
        return GridItem.gridItems.Where(tile => tile.containsPlayer && tile._light.isOn).Count() > 0;
    }
}
