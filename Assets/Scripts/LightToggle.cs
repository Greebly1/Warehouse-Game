using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    [SerializeField] public bool isOn { get; private set; } = false;
    [SerializeField] public GameObject lightContainer;
    [SerializeField] AudioClip switchSound;
    [SerializeField] Transform soundLocation;

    public static Action lightingUpdated = delegate { };
    public Action _localLightEnabled = delegate { };

    bool motionDetected = false;
    float _timeSinceMotion = 0f;

    [SerializeField] float minTime = 4f;
    [SerializeField] float maxTime = 10f;

    int lastSecond = 0;
    bool newSecond = false;

    float timeSinceMotion
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
        toggleLight(isOn);
    }

    void Update()
    {
        if (!motionDetected) { 
            timeSinceMotion = Time.deltaTime + _timeSinceMotion;

            if (isOn && newSecond)
            {
                randomToggle();
                Debug.Log("Random toggling!!!!");
            }
        }
    }

    public void toggleLight(bool _switch)
    {
        if (isOn == _switch) { return; } // Early out


        switch (_switch)
        {
            case true:
                lightContainer.SetActive(true);
                isOn = true;
                Debug.Log("Light turned on");
                break;
            case false:
                lightContainer.SetActive(false);
                isOn = false;
                Debug.Log("Light turned off");
                break;
        }
        AudioSource.PlayClipAtPoint(switchSound, soundLocation.position);

        lightingUpdated.Invoke();
        _localLightEnabled.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.player.pawn)
        {
            toggleLight(true);
            motionDetected = true;
        }
    }

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
    private void randomToggle()
    {
        float randomNum = UnityEngine.Random.Range(minTime, maxTime);
        if (randomNum - _timeSinceMotion < 0f)
        {
            toggleLight(false);
        }
    }
}
