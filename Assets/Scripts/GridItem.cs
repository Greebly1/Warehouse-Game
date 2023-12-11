using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    [HideInInspector] public static GridItem[,] Grid = {
    {null, null, null, null, null },
    {null, null, null, null, null },
    {null, null, null, null, null },
    {null, null, null, null, null },
    {null, null, null, null, null }
    };

    [HideInInspector] public static List<GridItem> gridItems = new List<GridItem>();
    
    [SerializeField] public int x;
    [SerializeField] public int y;

    [SerializeField] GameObject boxPrefab;

    [SerializeField] Transform boxSpawn;
    public bool containsBox;
    public bool containsPlayer;
    public bool containsMonster;

    [SerializeField] GameObject text;

    public LightToggle _light;

    private void Awake()
    {
        if (Grid[x,y] != this)
        {
            Grid[x,y] = this;
            gridItems.Add(this);
            pickupReceiver.pickedUpItem += boxPickedUp;
        }

        text.GetComponent<TextMeshPro>().text = "Locale " + new Vector2Int(x, y);
    }

    private void OnEnable()
    {
        _light._localLightEnabled += onEventLightSwitch;
    }

    private void OnDisable()
    {
        _light._localLightEnabled -= onEventLightSwitch;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerController.player.pawn != other.gameObject)
        {
            return; //Early out
        }

        containsPlayer = true;
        Debug.Log("Player stepped into "+ x + " , "+ y);
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerController.player.pawn != other.gameObject)
        {
            return; //Early out
        }

        containsPlayer = false;
        _light.toggleLight(false);
        Debug.Log("Player stepped out of " + x + " , " + y);
    }

    public void spawnBox()
    {
        if (containsBox) { Debug.Log("Already contains a box"); return; } // Early out

        containsBox = true;
        GameObject crate = Instantiate(boxPrefab, boxSpawn.position, boxSpawn.rotation);
        crate.transform.parent = this.gameObject.transform;

        HUD.instance.setLocale(new Vector2Int(x, y));
    }

    void boxPickedUp()
    {
        containsBox = false;
    }

    public void resetSelf()
    {
        _light.toggleLight(false);
        containsMonster = false;
        containsPlayer = false;
        containsBox = false;
    }

    void onEventLightSwitch()
    {
        if (containsMonster)
        {
            GameManager.Game.gameplayState.GetComponent<GameplayState>().gameOver();
        }
    }
}
