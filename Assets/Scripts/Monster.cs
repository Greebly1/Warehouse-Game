using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Monster : MonoBehaviour
{
    public static Monster Manager;

    public List<Vector2Int> monsters = new List<Vector2Int>(); //stores grid coordinates of tiles that contain monsters


    private void Awake()
    {
        Manager = this;
    }

    private void OnEnable()
    {
        monsters = new List<Vector2Int>();
        monsters.Add(new Vector2Int(2,1));
    }


    //gets all empty tiles and sets the monster bool to true for a random set of them
    //Do this after spawning a box
    //Make sure to killAllMonsters(); before calling this function
    public Monster spawnMonsters(int amount)
    {
        int numberOfMonsters = amount;

        if (numberOfMonsters == 10) { numberOfMonsters = 10; }

        List<GridItem> availableTiles = GridItem.gridItems.Where(tile => !tile.containsPlayer && !tile.containsMonster && !tile.containsBox).ToList();

        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, availableTiles.Count);

            availableTiles[randomIndex].containsMonster = true;

            Vector2Int location = new Vector2Int(availableTiles[randomIndex].x, availableTiles[randomIndex].y);

            monsters.Add(location);

            availableTiles.RemoveAt(randomIndex); //its more performant to do it this way so we don't need to loop through all of the tiles and make a new list of available tiles
        }

        printMonsters();

        return this;
    }


    public void printMonsters()
    {
        monsters.ForEach(monster => Debug.Log(monster));
    }

    //Only use this for spawning one monster, if spawning more than one monster use spawnMonsters(int amount);
    private Monster spawnMonster()
    {
        List<GridItem> availableTiles = GridItem.gridItems.Where(tile => !tile.containsPlayer && !tile.containsMonster && !tile.containsBox).ToList();

        int randomIndex = Random.Range(0, availableTiles.Count);

        availableTiles[randomIndex].containsMonster = true;

        return this;
    }

    public Monster killAllMonsters()
    {
        //GridItem.gridItems.ForEach(tile => tile.containsMonster = false);
        
        //This should work and be more performant than the above brute force method
        foreach (Vector2Int monster in monsters)
        {
            GridItem.Grid[monster.x, monster.y].containsMonster = false;
        }

        monsters = new List<Vector2Int>();
        return this;
    }
}
