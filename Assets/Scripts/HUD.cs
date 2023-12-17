using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//I believe off the top of my head, the HUD is a component on the camera, the camera also has the playercontroller script on it

public class HUD : MonoBehaviour
{
    public static HUD instance; //Singleton

    // This is the text in the to right of screen
    //It is meant to display the coordinates of where the new box is
    public GameObject locator; 
    public GameObject boxSprite; //this sprite tells the player they are holding a box
    //Only one of the above HUD elements will be active at a time

    private void Awake()
    {
        instance = this; //initialize singleton
    }

    //The boxsprite state logic uses events
    private void OnEnable()
    {
        pickupReceiver.pickedUpItem += Enablebox;
    }

    private void OnDisable()
    {
        pickupReceiver.pickedUpItem -= Enablebox;
    }

    //Enables the locator gameobject, diables the boxsprite, and sets the text to be the correct coordinates
    //This function is called by something else I dont remember
    public void SetLocale(Vector2Int coordinates)
    {
        locator.SetActive(true);
        locator.GetComponent<TextMeshProUGUI>().text = "Crate Locale : " + coordinates;

        boxSprite.SetActive(false);
    }


    //Enables the boxsprite and disables the locater
    //This function an event response to the pickupBox effect
    public void Enablebox()
    {
        locator.SetActive(false);

        boxSprite.SetActive(true);
    }
}
