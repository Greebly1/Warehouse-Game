using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

//What is a monster?
//A monster is simply, a boolean variable inside any particular tile.
//A monster can be accessed using an x and y coordinate
//This script isn't actually a monster, it just controls monsters, its the monster manager


public class Monster : MonoBehaviour
{
    public static Monster Manager; // singleton, you don't actually want more than one monster object Monster.manager just sounds like a cool way of accessing a singleton

    public List<Vector2Int> monsters = new List<Vector2Int>(); //stores grid coordinates of tiles that contain monsters


    private void Awake() //singleton logic
    {
        Manager = this;
    }

    private void OnEnable() 
    {
        monsters = new List<Vector2Int>(); //when the gameplay state begins, gridspace (2,1) is meant to have a monster in it
        monsters.Add(new Vector2Int(2,1)); //It is set here inside the monster class so nothing breaks
    }


    //gets all empty tiles and sets the monster bool to true for a random set of them
    //Make sure to killAllMonsters(); before calling this function
    public Monster SpawnMonsters(int amount)
    {
        int numberOfMonsters = amount;
        if (numberOfMonsters > 10) { numberOfMonsters = 10; } //max of 10 monsters

        //an available tile is one that doesn't contain anything
        List<GridItem> emptyTiles = GridItem.gridItems.Where(tile => !tile.containsPlayer && !tile.containsMonster && !tile.containsBox).ToList();

        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, emptyTiles.Count); //generate a random index

            emptyTiles[randomIndex].containsMonster = true; //the empty tile at that index now contains a monster

            Vector2Int location = new Vector2Int(emptyTiles[randomIndex].x, emptyTiles[randomIndex].y); //Update the monster list with a new monster location
            monsters.Add(location);

            emptyTiles.RemoveAt(randomIndex); //remove this tile from the list because it is no longer empty
        }

        return this;
    }

    //Used for debugging purposes
    public void PrintMonsters()
    {
        monsters.ForEach(monster => Debug.Log("monster at " + monster)); //monster is a vector2int
    }

    //The function name is cool, it clears all monsters
    public Monster KillAllMonsters()
    {
        //GridItem.gridItems.ForEach(tile => tile.containsMonster = false);
        
        //This should work and be more performant than the above brute force method
        foreach (Vector2Int monster in monsters) //the monsters list is a list of vector2ints, used to store their coordinates
        {
            GridItem.Grid[monster.x, monster.y].containsMonster = false; //simply access those coordinates and tell the tile it no longer contains a monster
        }

        monsters = new List<Vector2Int>(); // clear the list in the end
        return this;
    }
}
