using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Light toggle is a component that expects a triggerbox
//It will simply enable the lights and play a sound when a player enters
//And begins randomly checking if it will disable the light when the player leaves
public class LightToggle : MonoBehaviour
{
    [SerializeField] public bool isOn { get; private set; } = false;
    [SerializeField] public GameObject lightContainer; // this is set in the prefab, and contains all of the Unity Light objects as children
    [SerializeField] AudioClip switchSound; //Sound that plays when the switch occurs
    [SerializeField] Transform soundLocation;

    public static Action lightingUpdated = delegate { }; // static event that is used for updating the player light detector
    public Action _localLightEnabled = delegate { }; // event that the gridItem observes to know when its light turns on or off

    bool motionDetected = false; //whether a player is in the trigger or not
    float _timeSinceMotion = 0f; //how long the player has been outside of the trigger

    [SerializeField] float minTime = 4f; //The grace period, the light will not turn off for this many seconds after leaving
    [SerializeField] float maxTime = 10f; //The maximum time a light can stay on after leaving the detection zone

    int lastSecond = 0; // This is some weird float/int stuff so I don't check he above numbers 60 times or more in a single frame
    //I only want it to check once each second, not 120 times a second becauase that messes with the random statistics
    bool newSecond = false;

    float timeSinceMotion // property used to set the _timeSinceMotion variable so that newSecond and lastSecond are updated
    {
        set
        {
            _timeSinceMotion = value;
            if (lastSecond < _timeSinceMotion) {
                lastSecond++;
                newSecond = true;
            } else { newSecond = false; }
        }
    }

    void Awake()
    {
        ToggleLight(isOn);
    }

    void Update()
    {
        if (!motionDetected) { //if the player is not in the trigger
            timeSinceMotion = Time.deltaTime + _timeSinceMotion; //tick the timer

            if (isOn && newSecond) //if the light is on, and a second has passed, try to randomly turn off the light
            {
                RandomToggle();
                //Debug.Log("Random toggling!!!!");
            }
        }
    }

    //This function works like a SetState(newstate) function, however this only has two possible states on or off
    public void ToggleLight(bool _switch)
    {
        //You can't turn a light that's off, off again
        if (isOn == _switch) { return; } // Early out if the new state is the same


        switch (_switch)
        {
            case true: //light has been turned on
                lightContainer.SetActive(true); //enable lights
                isOn = true;
                Debug.Log("Light turned on");
                break;
            case false: //light has been turned off
                lightContainer.SetActive(false); //diable lights
                isOn = false;
                Debug.Log("Light turned off");
                break;
        }
        //play a sound regardless of whether it turned on or off,
        //it will early out if it tried to toggle the same state
        AudioSource.PlayClipAtPoint(switchSound, soundLocation.position);

        //invoke the events so the external game logic that deals with light can be updated
        lightingUpdated.Invoke();
        _localLightEnabled.Invoke();
    }

    //Turn the light on if the player enters this trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.player.pawn)
        {
            ToggleLight(true);
            motionDetected = true; //also set motiondetected to true
        }
    }

    //This does not turn off the light,
    //If the player leaves, it resets the timer and turns off motionDetected, so that the Update()
    //can do the shadow timer logic
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerController.player.pawn)
        {
            motionDetected = false;
            timeSinceMotion = 0f;
            lastSecond = 0;
            newSecond = false;
            Debug.Log("Starting random toggling");
        }
    }

    //generate a random number between a min and max number, then, subtract the time since motion was detected
    //If the resulting number is less than 0, turn the light off
    private void RandomToggle()
    {
        float randomNum = UnityEngine.Random.Range(minTime, maxTime);
        if (randomNum - _timeSinceMotion < 0f)
        {
            ToggleLight(false);
        }
    }
}
