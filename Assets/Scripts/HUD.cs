using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD instance;

    public GameObject locator;
    public GameObject boxSprite;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        pickupReceiver.pickedUpItem += enablebox;
    }

    private void OnDisable()
    {
        pickupReceiver.pickedUpItem -= enablebox;
    }

    public void setLocale(Vector2Int coordinates)
    {
        locator.SetActive(true);
        locator.GetComponent<TextMeshProUGUI>().text = "Crate Locale : " + coordinates;

        boxSprite.SetActive(false);
    }



    public void enablebox()
    {
        locator.SetActive(false);

        boxSprite.SetActive(true);
    }
}
