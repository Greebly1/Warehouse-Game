using System.Collections;
using System.Collections.Generic;
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

    [HideInInspector] public static List<GridItem> gridItems;

    [SerializeField] public int x;
    [SerializeField] public int y;

    [SerializeField] GameObject boxPrefab;

    [SerializeField] Transform boxSpawn;
    public bool containsBox { get; private set; } = false;
    public bool containsPlayer { get; private set; } = false;
    public LightToggle _light;

    private void Awake()
    {
        if (Grid[x,y] != this)
        {
            Grid[x,y] = this;
            gridItems.Add(this);
            pickupReceiver.pickedUpItem += boxPickedUp;
        }
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
        Instantiate(boxPrefab, boxSpawn.position, boxSpawn.rotation);
    }

    void boxPickedUp()
    {
        containsBox = false;
    }
}
