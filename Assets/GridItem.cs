using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] public int x;
    [SerializeField] public int y;

    private void Awake()
    {
        if (GridItem.Grid[x,y] != this)
        {
            GridItem.Grid[x,y] = this;
        }
    }


}
