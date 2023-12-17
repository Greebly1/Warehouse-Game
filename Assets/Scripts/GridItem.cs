using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    // Use this to access a GridItem with coordinates
    [HideInInspector] public static GridItem[,] Grid = new GridItem[5,5];
        
    // Use this to loop through every GridItem, for querying, resetting, etc.
    [HideInInspector] public static List<GridItem> gridItems = new List<GridItem>();
    
    [SerializeField] public int x; //The coordinates of this tile will be hardcoded in the inspector
    [SerializeField] public int y;

    [SerializeField] GameObject monster; //this gameobject set in the prefab is simply playing a heartbeat sound on repeat

    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform boxSpawn;

    //The following variables contain the state of the GridItem
    public bool containsBox;
    public bool containsPlayer;
    public bool containsMonster;
    //This component stores the light state of the grid, which is why its public
    //And contains methods for toggling the light
    public LightToggle _light; //This variable is set in the inspector from a prefab

    [SerializeField] GameObject text; //label of the coordinates

    private void Awake()
    {
        if (Grid[x,y] != this) //Initialize this individual GridItem
        {
            Grid[x,y] = this;
            gridItems.Add(this);
            pickupReceiver.pickedUpItem += BoxPickedUp;
        }

        text.GetComponent<TextMeshPro>().text = "Locale " + new Vector2Int(x, y);
    }

    private void OnEnable()
    {
        //this will check the lose condition whenever the light gets turned on
        _light._localLightEnabled += OnEventLightSwitch; 
        if (x == 2 && y == 0)
        {
            Debug.Log("box shouldve spawned");
            SpawnBox();
        } 

        if (x == 2 && y == 1)
        {
            containsMonster = true;
            //monster.SetActive(true);
        }
    }

    private void OnDisable()
    {
        _light._localLightEnabled -= OnEventLightSwitch;
    }

    private void OnTriggerEnter(Collider other)
    {
        //The following code is for updating the containsPlayer bool to true

        if (playerController.player.pawn != other.gameObject)
        {
            return; //Early out
        }

        containsPlayer = true;
        Debug.Log("Player stepped into "+ x + " , "+ y);

        if (containsMonster) //So this code seems strange because
        {
            //The griditem triggerbox, is a seperate larger triggerbox from the lightswitch trigger box
            //This section of code enables the monster heart beat sound when the player enters the tile.
            monster.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //The following code is for updating the containsPlayer bool to false
        if (playerController.player.pawn != other.gameObject)
        {
            return; //Early out
        }

        containsPlayer = false;
        _light.ToggleLight(false);
        Debug.Log("Player stepped out of " + x + " , " + y);

        if (containsMonster)
        {
            monster.SetActive(false);
        }
    }

    public void SpawnBox()
    {
        if (containsBox) { Debug.Log("Already contains a box"); return; } // Early out

        containsBox = true;
        GameObject crate = Instantiate(boxPrefab, boxSpawn.position, boxSpawn.rotation);
        crate.transform.parent = this.gameObject.transform; // this is likely a useless line of code

        HUD.instance.SetLocale(new Vector2Int(x, y));
    }

    //Event response for when any box is picked up
    void BoxPickedUp()
    {
        //this is just to reset all griditem's containsBox variable whenever a box is picked up
        //Although ResetSelf gets called anyways so it is likely useless
        containsBox = false;
    }

    //This is called by other scripts, usually also while looping through every GridItem
    public void ResetSelf()
    {
        _light.ToggleLight(false);
        containsMonster = false;
        containsPlayer = false;
        containsBox = false;
        monster.SetActive(false );
    }

    //This event response executes whenever the light in this grid turns on
    //This is located inside of the griditem because, the light does not know what griditem it is on, or if it has a monster on it
    //So the griditem is simply observing its light, and whenever the light turns on it checks its containsMonster state
    void OnEventLightSwitch()
    {
        if (containsMonster)
        {
            GameManager.Game.gameplayState.GetComponent<GameplayState>().GameOver();
        }
    }
}
